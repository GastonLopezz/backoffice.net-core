using Datos.Context;
using Datos.Entity;
using Datos.Entity.GlobalesEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Negocio.Dto;
using Negocio.Dto.Response;
using Negocio.Helpers;
using Negocio.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Negocio.Services {
    public class DocenteService : IDocenteService {
        private readonly ContextoParticular _context;
        private readonly BedeliasAppSettings _bedeliasSettings;

        public DocenteService(ContextoParticular ctx, IOptions<BedeliasAppSettings> bedelias) {
            _context = ctx;
            _bedeliasSettings = bedelias.Value;

        }

        public void ConfigurarClaveMatriculacion(int IdCurso, string Clave, string Opcion){
            var curso = getClave(IdCurso);
            if (Opcion.Equals("Borrar")){
                curso.ClaveMatriculacion = null;
            } else {
                curso.ClaveMatriculacion = Clave;
            }
            _context.SaveChanges();
        }
        
        public Curso getClave(int IdCurso){
            return _context.Curso.SingleOrDefault(t => t.Id == IdCurso);
        }

        public IEnumerable<PersonaCuentaResponse> GetEstudiantesDelCurso(int IdCurso){
            List<PersonaCuentaResponse> lst = new List<PersonaCuentaResponse>();
            PersonaCuentaResponse datos_estudiantes;

            var estudiantes_inscriptos = _context.Inscripcion
                .Include(e => e.CursoInscripcion)
                .Include(c => c.EsudianteInscripcion)
                .Where(x => x.CursoId == IdCurso && x.HabilitadoBedelia == true && x.Metriculado == true)
                .ToList();

            foreach (var est in estudiantes_inscriptos) {
                foreach (var p in _context.Cuenta.Include(p => p.PersonaCuenta).Where(x => x.Id == est.EsudianteInscripcionId))
                {
                    datos_estudiantes = new PersonaCuentaResponse(p.Id, p.PersonaCuenta.Nombre, p.PersonaCuenta.Apellido, p.Usuario, "Estudiante", false);
                    lst.Add(datos_estudiantes);
                }
            }
            return lst;
        }

        public bool DocenteEncargado(int IdCuenta, int IdCurso) {
            return _context.DocentesCurso.Any(x => x.DocenteId == IdCuenta && x.Escargado == true);
        }

        public IEnumerable<PersonaCuentaResponse> GetDocentesDelCurso(int IdCurso) {
            List<PersonaCuentaResponse> lst = new List<PersonaCuentaResponse>();
            PersonaCuentaResponse datos_docentes;
            var docentes = _context.DocentesCurso
               .Include(c => c.Docente)
               .Where(x => x.CursoId == IdCurso)
               .ToList();
            foreach (var doc in docentes) {
                foreach (var p in _context.Cuenta.Include(p => p.PersonaCuenta).Where(x => x.Id == doc.DocenteId))
                {
                    datos_docentes = new PersonaCuentaResponse(p.Id, p.PersonaCuenta.Nombre, p.PersonaCuenta.Apellido, 
                        p.Usuario, "Docente", doc.Escargado);
                    lst.Add(datos_docentes);
                }
            }
            return lst;
        }

        public bool AsignarDocente(int IdCurso, int idUserEncargado, int CiusuarioNuevoDocente)
        {
            var docente = _context.DocentesCurso
                .Include(c => c.Docente)
                .SingleOrDefault(x => x.Docente.Id == idUserEncargado && x.Escargado == true && x.CursoId == IdCurso);
            if (docente != null) {
                var nuevoDocente = _context.Cuenta
                    .Include(x=> x.PersonaCuenta)
                    .SingleOrDefault(x => x.PersonaCuenta.Ci == CiusuarioNuevoDocente && x.TipoCuenta=="Docente");
                if (nuevoDocente!=null) {
                    var dc = new DocentesCurso() {
                        CursoId = IdCurso,
                        DocenteId = nuevoDocente.Id,
                        Escargado = false
                    };
                    _context.DocentesCurso.Add(dc);
                    _context.SaveChanges();
                    return true;
                }
           
                return false;
            }
            return false;
        }

        public void BorrarDocenteAsignado(int IdCurso,int idDocenteBorrar){
            var docente = _context.DocentesCurso
            .Include(c => c.Docente)
            .SingleOrDefault(x => x.Docente.Id == idDocenteBorrar && x.Escargado == false && x.CursoId == IdCurso);
            if (docente != null){       
                _context.DocentesCurso.Remove(docente);
                _context.SaveChanges();
            }
        }

        public void AddDocente(Cuenta d) {
            _context.Cuenta.Add(d);
            _context.SaveChanges();
        }
		
		public void DeleteDocenteAsignacion(int idCurso, int IdCuenta) {
            var d = _context.DocentesCurso.SingleOrDefault(t => t.DocenteId == IdCuenta && t.CursoId == idCurso);
            _context.DocentesCurso.Remove(d);
            _context.SaveChanges();
            //Borar base de datos cuando se borra la facultad
        }
        
        public void DeleteDocente(int IdCuenta) {
            var d = _context.Cuenta.SingleOrDefault(t => t.Id == IdCuenta);
            _context.Cuenta.Remove(d);
            _context.SaveChanges();
            //Borar base de datos cuando se borra la facultad
        }

        public void ModifyDocente(Cuenta model) {
            var f = _context.Cuenta.SingleOrDefault(t => t.Id == model.Id);
            f.Usuario = model.Usuario;
            f.Passwd = model.Passwd;
            f.Email = model.Email;
            f.NumeroTelefono = model.NumeroTelefono;
            f.TipoCuenta = model.TipoCuenta;
            _context.SaveChanges();
        }


        public bool ValidateDocente(string usuario) {
            return _context.Cuenta.Any(t => t.Usuario == usuario);
        }

		 public bool AsignarDocenteCurso(int idCurso, int idDocente) {
            var dc = new DocentesCurso() {
                CursoId = idCurso,
                DocenteId = idDocente,
                Escargado = true
            };
            _context.DocentesCurso.Add(dc);
            _context.SaveChanges();
            return true;
        }
        
        public List<Cuenta> ListarDocente() {
            return _context.Cuenta.ToList();
        }

        public Cuenta get(int id) {
            var f = _context.Cuenta.SingleOrDefault(t => t.Id == id);
            return f;
        }

        public string IngresarNotaFinal(int idCurso, int ci, int notaFinal)
        {
            var cuenta = _context.Cuenta.SingleOrDefault(c => c.PersonaCuenta.Ci == ci);
            var curso = _context.Curso.SingleOrDefault(c => c.Id == idCurso);
            if(cuenta != null && curso != null)
            {
                var request = (HttpWebRequest)WebRequest.Create(_bedeliasSettings.Url+"IngresarNota");
                request.ContentType = "application/json";
                request.Method = WebRequestMethods.Http.Post;
                request.Accept = "application/json";
                request.SendChunked = true;
                request.TransferEncoding = Encoding.UTF8.WebName;
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        Ci = ci,
                        CursoHabilitadoID = idCurso,
                        Calificacion = notaFinal
                    });

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (string.IsNullOrEmpty(result))
                    {
                        return "Se ha ingresado la nota final.";
                    }
                    else
                    {
                        return result;
                    }
                }
                
            }
            return "No existe el ususario o el curso.";
        }

		public List<Persona> ListarDocente2() {
            List<Persona> lstP = new List<Persona>();
            var cuentas = _context.Cuenta.Where(c => c.TipoCuenta == "Docente")
                 .ToList();
            foreach (var c in cuentas) {
                lstP.Add(_context.Persona.SingleOrDefault(x => x.Id == c.PersonaId));
            }
            return lstP;
        }
        
        public string EditarNotaFinal(int idUsuario, int cursoId, int calificacion)
        {
            var cuenta = _context.Cuenta.SingleOrDefault(c => c.PersonaCuenta.Id == idUsuario);
            var curso = _context.Curso.SingleOrDefault(c => c.Id == cursoId);
            if (cuenta != null && curso != null)
            {
                var request = (HttpWebRequest)WebRequest.Create(_bedeliasSettings.Url+"EditarNotaFinal");
                request.ContentType = "application/json";
                request.Method = WebRequestMethods.Http.Post;
                request.Accept = "application/json";
                request.SendChunked = true;
                request.TransferEncoding = Encoding.UTF8.WebName;
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        IdUsuario = cuenta.Id,
                        CursoId = curso.Id,
                        Calificacion = calificacion
                    });

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (string.IsNullOrEmpty(result))
                    {
                        return "Se ha editado la nota final.";
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            return "No existe el ususario o el curso.";
        }

        public string ObtenerNotaCurso(int ci, int cursoId, int FacultadId) 
        {
            var request = (HttpWebRequest)WebRequest.Create(_bedeliasSettings.Url+"ObtenerNota?Ci=" + ci + "&CursoId=" + cursoId+ "&FacultadId=" + FacultadId);
            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        public List<string> ObtenerNotasEstudiante(int ci, int FacultadId)
        {
            List<string> notas = new List<string>();
            var request = (HttpWebRequest)WebRequest.Create(_bedeliasSettings.Url+"ObtenerNotaSFacultad?ci=" + ci + "&FacultadId=" + FacultadId);
            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            string[] result = responseString.Split(',', '[',']');
            foreach (var item in result)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    notas.Add(item);
                }
            }
            return notas;

        }

		public List<Curso> ListarCursosDocente(int idCuentaDocente) {
            List<Curso> LstCursos = new List<Curso>();
            var cd = _context.DocentesCurso.Where(c => c.DocenteId == idCuentaDocente).ToList();
            foreach (var i in cd) {
                var t = _context.Curso.SingleOrDefault(t => t.Id == i.CursoId);
                LstCursos.Add(t);
            }
            return LstCursos;
        }


    }
 }
