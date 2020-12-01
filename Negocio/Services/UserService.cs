using Datos.Context;
using Datos.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Negocio.Dto;
using Negocio.Helpers;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Negocio.Services.Password;
using Datos.Entity.GlobalesEntity;
using System.Net.Mail;
using Negocio.Dto.Response;
using System.Net;
using System.IO;

namespace Negocio.Services {
    public class UserService : IUserService{

        private readonly AppSettings _appSettings;
        private readonly ContextoParticular _context;
        private readonly ContextoGeneral _contextoGeneral;
        private readonly SmtpSettings _smtpSettings;
        private readonly BedeliasAppSettings _bedeliasSettings;

        public UserService(IOptions<AppSettings> appSettings, ContextoParticular ctx,
            ContextoGeneral ctG, IOptions<SmtpSettings> smtpSettings, IOptions<BedeliasAppSettings> bedelias) {
            _appSettings = appSettings.Value;
            _context = ctx;
            _contextoGeneral = ctG;
            _smtpSettings = smtpSettings.Value;
            _bedeliasSettings = bedelias.Value;

        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model) {
            var user = VerificarLogin(model.Username,model.Password);
            if (user == null) {   // return null if user not found
                return null;
            } else {
                // authentication successful so generate jwt token
                var token = generateJwtToken(user);

                return new AuthenticateResponse(user, token);
            }

        }

        public AuthenticateResponse AuthenticateGoogle(string googleId) {
            var user=VerificarCuentaGoogle(googleId);
            if (user == null) {
                return null;
            } else {
                var token = generateJwtToken(user);
                return new AuthenticateResponse(user, token);
            }
            
        }

        private Cuenta VerificarCuentaGoogle(string googleId) {
         return _context.Cuenta
                .Include(c=> c.CuentaGoogle)
                .Include(p=> p.PersonaCuenta)
                .SingleOrDefault(x => x.CuentaGoogle.GoogleId == googleId);
        }

        public Cuenta VerificarLogin(string usuario, string passwd) {
            var user = _context.Cuenta
                  .Include(c => c.PersonaCuenta)
                  .SingleOrDefault(x => x.Usuario == usuario);
            if (user != null) {
                bool verifico = PassHash.Validate(passwd, user.Salt, user.Passwd);
                if (verifico) {
                    return user;
                }
            }
            return null;

        }
        public bool CrearCuentaAdministrador(string nombre, string apellido, string usuario, string password,string tipoAdministrador,int IdFacultad) {
            try {
                var salt = PassSalt.Create();
                var hash = PassHash.Create(password, salt);
                var administrador = new Administrador() {
                    Nombre = nombre,
                    Apellido=apellido,
                    Usuario=usuario,
                    Passwd=hash,
                    Salt=salt
                };
                _contextoGeneral.Administrador.Add(administrador);
                _contextoGeneral.SaveChanges();

                if (tipoAdministrador == "Facultad") {
                    var tipoAdminFac = new AdministradorFacultad() {
                        FacultadId=IdFacultad,
                        AdministradorId=administrador.Id
                    };
                    _contextoGeneral.AdministradorFacultad.Add(tipoAdminFac);

                } else {
                    var tipoAdminUdelar = new AdministradorUdelar() {
                        AdministradorId = administrador.Id
                    };
                    _contextoGeneral.AdministradorUdelar.Add(tipoAdminUdelar);
                }
                _contextoGeneral.SaveChanges();

            } catch(Exception ex) {
                Console.WriteLine(ex);
                return false;
            }
            return true;

        }


        public bool CrearCuenta(CreateUserRequest model) {
            if (model.GoogleId==null) {//Register Interno
                if (!VerificarCuentaDatos(model.Usuario, model.Cedula)) {//si esto es falso osea que no hay datos existentes
                    var salt = PassSalt.Create();
                    var hash = PassHash.Create(model.Password, salt);
                    try {
                        var persona = new Persona() {
                            Ci = model.Cedula,
                            Nombre = model.Nombre,
                            Apellido = model.Apellido,
                        };
                        _context.Persona.Add(persona);
                        _context.SaveChanges();

                        var cuenta = new Cuenta() {
                            Usuario = model.Usuario,
                            Passwd = hash,//Hash
                            Salt = salt,//Salt
                            Email = model.Email,
                            NumeroTelefono = model.Telefono,
                            TipoCuenta = model.TipoCuenta,
                            PersonaId = persona.Id,
                        };
                        _context.Cuenta.Add(cuenta);
                        _context.SaveChanges();

                        return true;
                    } catch (Exception ex) {
                        Console.WriteLine(ex);
                        return false;
                    }

                }
            } else {//Register google
                var user = VerificarCuentaGoogle(model.GoogleId);
                if (user==null) {
                    var persona = new Persona() {
                        Ci = model.Cedula,
                        Nombre = model.Nombre,
                        Apellido = model.Apellido,
                    };
                    _context.Persona.Add(persona);
                    _context.SaveChanges();

                    var cuenta = new Cuenta() {
                        Usuario = model.GoogleId,
                        Email = model.Email,
                        NumeroTelefono = model.Telefono,
                        TipoCuenta = model.TipoCuenta,
                        PersonaId = persona.Id,
                    };
                    _context.Cuenta.Add(cuenta);
                    _context.SaveChanges();

                    var cunetaGoogle = new CuentaGoogle() {
                        CuentaId = cuenta.Id,
                        GoogleId = model.GoogleId,
                        ImgUrl=model.ImgUrl
                    };
                    _context.CuentaGoogle.Add(cunetaGoogle);
                    _context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

    
        public bool VerificarCuentaDatos(string usuario,int ci) {
            bool u= _context.Cuenta.Any(x=> x.Usuario == usuario);
            bool c = _context.Persona.Any(x => x.Ci == ci);
            if (u && c) {
                var request = (HttpWebRequest)WebRequest.Create(_bedeliasSettings.Url+"valido?Ci=" +ci);
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (responseString.Contains("true"))
                {
                    return true;
                }
                return false;
            }
            return false;

            
        }

        public IEnumerable<Cuenta> GetAll() {
                return _context.Cuenta.ToList();            
        }
        public bool EnviarMailForgotPassword(string email) {
          var verificoExistencia=_context.Cuenta
                .Include(c=> c.CuentaGoogle)
                .SingleOrDefault(x=> x.Email ==email);
            var cuentaGoogle = _context.CuentaGoogle.Any(c => c.CuentaPersona.Id == verificoExistencia.Id);

            if (verificoExistencia!=null && cuentaGoogle==false) { 

                try {
                  var codigoNuevaPassword=ForgotPasswordUpdate(verificoExistencia);

                    string To = email;
                    string Subject = "Recuperacion de Contraseña";
                    string Body = "Codigo para cambio de contraseña: "+ codigoNuevaPassword;
                    MailMessage mm = new MailMessage();
                    mm.To.Add(To);
                    mm.Subject = Subject;
                    mm.Body = Body;
                    mm.IsBodyHtml = false;
                    mm.From = new MailAddress(_smtpSettings.Username);
                    SmtpClient smtp = new SmtpClient(_smtpSettings.Server);
                    smtp.Port = _smtpSettings.Port;
                    smtp.UseDefaultCredentials = true;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                    smtp.SendMailAsync(mm);
                    return true;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return false;
                }
            }             
            return false;
        }

        private string ForgotPasswordUpdate(Cuenta user) {
            string password = Guid.NewGuid().ToString("N").ToLower()
                  .Replace("1", "").Replace("o", "").Replace("0", "")
                  .Substring(0, 10);
            string salt = PassSalt.Create();
            string hash = PassHash.Create(password, salt);
            user.Passwd = hash;
            user.Salt = salt;
            _context.SaveChanges();

            return password;
        }
       public  bool ActualizarPassword(string email, string passwordAntiguo,string passwordActual){
            var c = _context.Cuenta.SingleOrDefault(x => x.Email == email);
            Cuenta cuenta=VerificarLogin(c.Usuario, passwordAntiguo);
            if (cuenta != null){
                string salt = PassSalt.Create();
                string hash = PassHash.Create(passwordActual, salt);
                cuenta.Passwd = hash;
                cuenta.Salt = salt;
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public Cuenta GetById(int id) {
             return _context.Cuenta.SingleOrDefault(t => t.Id == id);
        }
        public Administrador get(int id) {
            return new Administrador();
        }

        private string generateJwtToken(Cuenta user) {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

         public void AddAdministrador(Administrador a, string tipo, int idFacultad) {
            _contextoGeneral.Administrador.Add(a);
            _contextoGeneral.SaveChanges();
            if (tipo == "Facultad") {
                var af = new AdministradorFacultad() {
                    AdministradorId = a.Id,
                    FacultadId = idFacultad
                };
                _contextoGeneral.AdministradorFacultad.Add(af);
                _contextoGeneral.SaveChanges();
            } else {
                var au = new AdministradorUdelar() { 
                    AdministradorId=a.Id
                };
                _contextoGeneral.AdministradorUdelar.Add(au);
                _contextoGeneral.SaveChanges();
            }
        }

        public void DeleteAdministrador(int IdAdministrador) {
            var a = _contextoGeneral.Administrador.SingleOrDefault(t => t.Id == IdAdministrador);
            _contextoGeneral.Administrador.Remove(a);
            _contextoGeneral.SaveChanges();
            //Borar base de datos cuando se borra la facultad
        }

        public void ModifyAdministrador(Administrador model) {
            var f = _contextoGeneral.Administrador.SingleOrDefault(t => t.Id == model.Id);
            f.Nombre = model.Nombre;
            f.Apellido = model.Apellido;
            _contextoGeneral.SaveChanges();
        }


        public bool ValidateAdministrador(string usuario) {
            return _contextoGeneral.Administrador.Any(t => t.Usuario == usuario);
        }

        public List<Administrador> ListarAdministrador() {
            return _contextoGeneral.Administrador.ToList();
        }

        public PersonaCuentaResponse VerificarLoginAdministradores(string usuario, string passwd) {
            var user = _contextoGeneral.Administrador
                  .Include(c => c.AdminFacultad)
                  .Include(c => c.AdminUdelar)
                  .SingleOrDefault(x => x.Usuario == usuario);
            if (user != null) {
                bool verifico = PassHash.Validate(passwd, user.Salt, user.Passwd);
                if (verifico) {
                    var tipoUsaurio = "Facultad";
                    var adminF = _contextoGeneral.AdministradorFacultad
                     .SingleOrDefault(x => x.AdministradorId == user.Id);
                    if (adminF == null) {
                        tipoUsaurio = "Udelar";
                    }
                    return new PersonaCuentaResponse(user.Id, user.Nombre, user.Apellido, user.Usuario, tipoUsaurio, true);
                }
            }
            return null;
        }

        public Persona getDocente(int idCuenta) {
            var c = _context.Cuenta.SingleOrDefault(t => t.Id == idCuenta);
            return _context.Persona.SingleOrDefault(i => i.Id == c.PersonaId);
        }
        
        public void ModifyDocente(Persona model) {
            var f = _context.Persona.SingleOrDefault(t => t.Id == model.Id);
            f.Nombre = model.Nombre;
            f.Apellido = model.Apellido;
            _context.SaveChanges();
        }

        public int GetCi(int idUsuario) {
           return _context.Cuenta.Include(x=>x.PersonaCuenta).SingleOrDefault(t => t.Id ==idUsuario).PersonaCuenta.Ci;

        }
    }
}