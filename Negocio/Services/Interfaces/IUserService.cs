using Datos.Entity;
using Negocio.Dto.Response;
using Negocio.Dto;

using System;
using System.Collections.Generic;
using System.Text;
using Datos.Entity.GlobalesEntity;

namespace Negocio.Services.Interfaces {

    public interface IUserService {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        AuthenticateResponse AuthenticateGoogle(string googleId);

        IEnumerable<Cuenta> GetAll();
        Cuenta GetById(int id);
        Cuenta VerificarLogin(string usuario, string passwd);
        bool CrearCuenta(CreateUserRequest model);
        bool VerificarCuentaDatos(string usuario,int ci);
        bool CrearCuentaAdministrador(string nombre,string apellido,string usuario,string password,string tipoAdministrador,int IdFacultad);
        bool EnviarMailForgotPassword(string email);
        bool ActualizarPassword(string email, string passwordAntiguo,string passwordActual);
        Administrador get(int id);
        void AddAdministrador(Administrador a, string tipo, int idFacultad);
        void DeleteAdministrador(int IdAdministrador);
        void ModifyAdministrador(Administrador model);
        bool ValidateAdministrador(string usuario);
        List<Administrador> ListarAdministrador();
        PersonaCuentaResponse VerificarLoginAdministradores(string usuario, string passwd);
        void ModifyDocente(Persona model);
        Persona getDocente(int id);
        int GetCi(int idUsuario);

    }

}
