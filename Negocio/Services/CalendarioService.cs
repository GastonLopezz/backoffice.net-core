using Datos.Context;
using Datos.Entity;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Services
{
    public class CalendarioService : ICalendarioService
    {
        private readonly ContextoParticular _context;

        public CalendarioService(ContextoParticular ctx)
        {
            _context = ctx;
        }

        public string NuevoEvento(int cursoId, string titulo, string facultad, DateTime fecha)
        {
            string ret = "";
            try
            {
                Curso curso = _context.Curso.Find(cursoId);
                if (curso != null) {
                    Calendario cal = new Calendario(){
                        CursoId = curso.Id,
                        Fecha = fecha,
                        Titulo = titulo
                    };
                    _context.Calendario.Add(cal);
                    _context.SaveChanges();
                    return ret;
                }
                return ret = "No existe el curso.";
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }

        public string BorrarEvento(int cursoId,DateTime fecha)
        {
            string ret = "";
            try
            {
                var calendario = _context.Calendario.SingleOrDefault(x => x.CursoId == cursoId && x.Fecha == fecha);
                if(calendario != null)
                {
                    _context.Remove(calendario);
                    _context.SaveChanges();
                    return ret;
                }
                return ret = "No existe el curso que se intenta borrar.";
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }


        public string ObtenerEvento(int cursoId,DateTime fecha) {
            var mensaje = "";
            try {
               mensaje= _context.Calendario.SingleOrDefault(x => x.CursoId == cursoId && x.Fecha == fecha).Titulo;
            } catch (Exception ex) {
                return "Sin Evento";
            }
            return mensaje;
        
    }
    public List<DateTime> ObtenerEventos(int cursoId)
        {
            List<DateTime> fechas = new List<DateTime>();

            var data=_context.Calendario.Where(x=>x.CursoId==cursoId).ToList();
            foreach(var f in data) {
                fechas.Add(f.Fecha);
            }
            return fechas;
        }
    }
}
