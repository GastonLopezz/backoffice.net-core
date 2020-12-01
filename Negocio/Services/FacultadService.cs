using Datos;
using Datos.Entity;
using Datos.Context;
using Datos.Entity.GlobalesEntity;
using Microsoft.EntityFrameworkCore;
using Negocio.Dto;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio.Dto.Response;

namespace Negocio.Services
{
    public class FacultadService : IFacultadesService
    {
        private readonly ContextoGeneral _context;
        private readonly ContextoParticular _contextParticular;
        private readonly ISQLUtil _sqlutil;

        public FacultadService(ContextoGeneral ctx, ContextoParticular ctxPart, ISQLUtil SQLUtil)
        {
            _context = ctx;
            _contextParticular = ctxPart;
            _sqlutil = SQLUtil;
        }
        public void AddFacultad(Facultad f)
        {
            _context.Facultad.Add(f);
            _context.SaveChanges();
            _sqlutil.CrearSchema(f.Abreviatura);

        }

        public void AddComunicadosFacultad(Comunicado c) {
            _context.Comunicado.Add(c);
            _context.SaveChanges();
        }

        public void DeleteFacultad(int IdFacultad)
        {
            var f = _context.Facultad.SingleOrDefault(t => t.Id == IdFacultad);
            _context.Facultad.Remove(f);
            _context.SaveChanges();
            _sqlutil.BorrarSchema(f.Abreviatura);
            //Borar base de datos cuando se borra la facultad
        }

        public void ModifyFacultad(Facultad model)
        {
            var f = _context.Facultad.SingleOrDefault(t => t.Id == model.Id);
            f.Nombre = model.Nombre;
            f.Abreviatura = model.Abreviatura;
            f.Url = model.Url;
            _context.SaveChanges();
        }


        public bool ValidateFacultad(string abreviatura, string url)
        {
            return _context.Facultad.Any(t => t.Abreviatura == abreviatura || t.Url == url);
        }
        public string TipoAutenticacion()
        {
            return _context.Facultad.First().TipoAutenticacion;
        }
        public List<Facultad> ListarFacultades()
        {
            return _context.Facultad.ToList();
        }

        public void PublicarComunicadoFacultad(int IdFacultades, string titulo, string texto, int IdAdministrador){
            var comunicado = new Comunicado() {
                Titulo = titulo,
                Texto = texto,
                FechaPublicacion = DateTime.UtcNow.Date,
                AdministradorId = IdAdministrador
            };
            _context.Comunicado.Add(comunicado);
            _context.SaveChanges();
            var facultadComunicado = new ComunicadoFacultad(){
                FacultadId = IdFacultades,
                ComunicadoId = comunicado.Id
            };
            _context.ComunicadoFacultad.Add(facultadComunicado);
            _context.SaveChanges();
        }



        public List<CursoResponse> ObtenerCursos()
        {
            List<CursoResponse> lst = new List<CursoResponse>();
            var lstCursos = _contextParticular.Curso.ToList();
            foreach (var c in lstCursos)
            {
                var nuevoCurso = new CursoResponse()
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Publico = c.ClaveMatriculacion == null ? true : false,
                    Creditos = c.Creditos

                };
                lst.Add(nuevoCurso);
            }
            return lst;
        }
        public List<ComunicadoResponse> ComunicadoFacultades(string urlFacultad) {
            List<ComunicadoResponse> lstComunicadoResponse = new List<ComunicadoResponse>();
            Facultad f = getFacultad(urlFacultad);
            var lstComFac = _context.ComunicadoFacultad.Where(i => i.FacultadId == f.Id).ToList();
            foreach (var c in lstComFac)
            {
                Comunicado comunicado = _context.Comunicado.SingleOrDefault(x => x.Id == c.ComunicadoId);
                ComunicadoResponse nuevoComunicado = new ComunicadoResponse()
                {
                    Id = comunicado.Id,
                    Titulo = comunicado.Titulo,
                    Texto = comunicado.Texto,
                    Fecha = comunicado.FechaPublicacion
                };
                lstComunicadoResponse.Add(nuevoComunicado);
            }
            return lstComunicadoResponse;
        }


        private Facultad getFacultad(string Url) {
            return _context.Facultad.SingleOrDefault(x => x.Url == Url);
        }

        public Facultad get(int id) {
            var f = _context.Facultad.SingleOrDefault(t => t.Id == id);
            return f;
        }

        public void ActualizarAutenticacion(int idFacultad, string tipoAuth) {
            var facultad = _context.Facultad.SingleOrDefault(x => x.Id == idFacultad);
            facultad.TipoAutenticacion = tipoAuth;
            _context.SaveChanges();
        }

        public FacultadDataResponse DatosFacultad(string url) {
            var facultad= _context.Facultad.SingleOrDefault(x=>x.Url==url);

            return new FacultadDataResponse() {
                Nombre = facultad.Nombre,
                Abreviatura=facultad.Abreviatura,
                Logo=facultad.Logo,
                ColorNav=facultad.ColorNav,
                TipoNav=facultad.TipoNav
            };
        }
    }
}
