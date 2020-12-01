using Datos.Context;
using Datos.Entity;
using Datos.Entity.GlobalesEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Negocio.Dto;
using Negocio.Dto.Response;
using Negocio.Helpers;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Negocio.Services{
    public class CursoService:ICursoService{
        private readonly ContextoParticular _context;
        private readonly BedeliasAppSettings _bedeliasSettings;
        public CursoService(ContextoParticular ctx, IOptions<BedeliasAppSettings> bedelias){
            _context = ctx;
            _bedeliasSettings = bedelias.Value;
        }
        public IEnumerable<CursoResponse> ObtenerCursos() {
            List<CursoResponse> lst = new List<CursoResponse>();
            Console.WriteLine(_context.SchemaName);
            var lstCursos= _context.Curso.ToList();
            foreach(var c in lstCursos) {
                var nuevoCurso = new CursoResponse() {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Publico = c.ClaveMatriculacion == null ? true : false,
                    YearDictado=c.YearDiactado,
                    Creditos=c.Creditos,
                    Informacion=c.Informacion,
                    DictaCurso=c.DictaCurso,
                    TipoCurso=c.TipoCurso
                };
                lst.Add(nuevoCurso);
            }
            return lst;
        }
  
        public string MatricularmeACurso(int idCurso, string clave, int IdUsuario,int FacultadId){
            if (_context.Inscripcion.Any(x=> x.CursoId==idCurso && IdUsuario==x.EsudianteInscripcionId)){//ya esta matriculado
                return "Ya esta Matriculado";
            }else  if (_context.Curso.Any(x => x.ClaveMatriculacion == clave && x.Id == idCurso)){

                var request = (HttpWebRequest)WebRequest.Create(_bedeliasSettings.Url+"Habilitado?IdUsuario="+IdUsuario+"&CursoId="+idCurso+ "&FacultadId=" + FacultadId);
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (responseString.Equals("false"))
                {
                    return "No esta habilitado.";
                }

                var inscrpcion = new Inscripcion()
                {
                    CursoId = idCurso,
                    EsudianteInscripcionId = IdUsuario,
                    FechaInscripcion = DateTime.Now,
                    Metriculado = true,
                    HabilitadoBedelia = true
                };
                _context.Inscripcion.Add(inscrpcion);
                _context.SaveChanges();
                return "Listo";
            }

            return "Error al matricularse";

        }
        public List<CursoResponse> MisCursos(int usuarioId) {
            List<CursoResponse> lst = new List<CursoResponse>();
            var inscriptos= _context.Inscripcion.Where(i => i.Metriculado == true && i.HabilitadoBedelia == true && i.EsudianteInscripcionId == usuarioId).ToList();
            foreach(var i in inscriptos) {
                var curso = _context.Curso.SingleOrDefault(x => x.Id == i.CursoId);
                var c = new CursoResponse() {
                    Id = curso.Id,
                    Nombre = curso.Nombre,
                    Creditos = curso.Creditos,
                    Informacion = curso.Informacion,
                    DictaCurso = curso.DictaCurso,
                    YearDictado = curso.YearDiactado,
                    TipoCurso=curso.TipoCurso
                };
                lst.Add(c);
            }
            return lst;
        }
        public List<CursoResponse> MisCursosDocente(int usuarioId) {
            List<CursoResponse> lst = new List<CursoResponse>();
            var curso_doc = _context.DocentesCurso.Where(i => i.DocenteId==usuarioId).ToList();
            foreach (var i in curso_doc) {
                var curso = _context.Curso.SingleOrDefault(x => x.Id == i.CursoId);
                var c = new CursoResponse() {
                    Id = curso.Id,
                    Nombre = curso.Nombre,
                    Creditos = curso.Creditos,
                    Informacion = curso.Informacion,
                    DictaCurso = curso.DictaCurso,
                    YearDictado = curso.YearDiactado,
                    TipoCurso = curso.TipoCurso
                };
                lst.Add(c);
            }
            return lst;
        }

        public List<SeccionTemplate> GetDataCurso(int idCurso) {
            return _context.SeccionTemplate
                    .Include(x=> x.EncuestaCursos)
                    .Include(x => x.Evaluaciones)
                   .Include(x => x.Materiales)
                   .Include(x=>x.Informaciones)
                    .Include(x=>x.Foros)
                    .Where(x => x.CursoId == idCurso)
                    .OrderBy(x => x.Prioridad)
                    .ToList();
        }

        public void BorrarSeccion(int SeccionId) {
            var c = _context.SeccionTemplate.SingleOrDefault(t => t.Id == SeccionId);
            _context.SeccionTemplate.Remove(c);
            _context.SaveChanges();

        }
        public void AgregarSeccion(int cursoId, string nombre) {
            var st = new SeccionTemplate() {
                Titulo=nombre,
                CursoId=cursoId,
                Visible = true,
        };
            _context.SeccionTemplate.Add(st);
            _context.SaveChanges();
        }

        public string GetNombreCurso(int Id) {
            return _context.Curso.SingleOrDefault(x => x.Id == Id).Nombre;
        }

        public bool ValidateCurso(string nombre) {
            return _context.Curso.Any(t => t.Nombre == nombre);
        }

        public void AddCurso(Curso c) {
            _context.Curso.Add(c);
            _context.SaveChanges();
        }

        public void DeleteCurso(int IdCurso) {
            var c = _context.Curso.SingleOrDefault(t => t.Id == IdCurso);
            _context.Curso.Remove(c);
            _context.SaveChanges();
        }

        public void ModifyCurso(Curso model) {
            var c = _context.Curso.SingleOrDefault(t => t.Id == model.Id);
            c.Nombre = model.Nombre;
            c.Creditos = model.Creditos;
            c.YearDiactado = model.YearDiactado;
            _context.SaveChanges();
        }
     
        public Curso get(int id) {
            var c = _context.Curso.SingleOrDefault(t => t.Id == id);
            return c;
        }

        public List<Curso> ListarCurso() {
            return _context.Curso.ToList();
        }

        public void AddComunicadosCurso(ComunicadoCurso c) {
            _context.ComunicadoCurso.Add(c);
            _context.SaveChanges();
        }

        public void PublicarComunicadoCurso(int IdCurso, string titulo, string texto) {
            var comunicado = new ComunicadoCurso() {
                Titulo = titulo,
                Texto = texto,
                FechaPublicacion = DateTime.UtcNow.Date,
                CursoId = IdCurso   
            };
            _context.ComunicadoCurso.Add(comunicado);
            _context.SaveChanges();
        }

        public List<ComunicadoCurso> ListarComunicadoCurso(int CursoId) {
         return _context.ComunicadoCurso.Where(z => z.CursoId == CursoId).ToList();
         
        }
    }
}
