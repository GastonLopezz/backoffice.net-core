using Datos.Context;
using Datos.Entity;
using Microsoft.EntityFrameworkCore;
using Negocio.Dto.Response;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Services
{
    public class ClaseService : IClaseService
    {
        private ContextoParticular _context;
        public ClaseService(ContextoParticular ctx)
        {
            _context = ctx;
        }

        public void AgregarAsistencia(int idClase, int idUsuario)
        {
                Asistencia a = new Asistencia()
                {
                    ClaseId = idClase,
                    CuentaId = idUsuario
                };
                _context.Asistencias.Add(a);
                _context.SaveChanges();
                
        }

        public string NuevaClase(int cursoId, DateTime fecha, DateTime start, DateTime end)
        {
            Curso curso = _context.Curso.Find(cursoId);
            if(curso != null)
            {
                Clase clase = new Clase()
                {
                    Curso = curso,
                    CursoId = curso.Id,
                    FechaClase = fecha,
                    Start = start,
                    End = end
                };
                _context.Clases.Add(clase);
                _context.SaveChanges();
                return "";
            }
            return "No existe el curso para el cual se quiere agregar la clase.";
        }

        public string EliminarClase(int idClase)
        {
            Clase clase = _context.Clases.Find(idClase);
            if(clase != null)
            {
                _context.Clases.Remove(clase);
                _context.SaveChanges();
                return "";
            }
            return "No existe la clase que se intenta eliminar.";
        }

        public string ModificarClase(int idClase, DateTime fecha, DateTime start, DateTime end)
        {
            Clase clase = _context.Clases.Find(idClase);
            if (clase != null){
                clase.Start = start;
                clase.End = end;
                clase.FechaClase = fecha;
                _context.Clases.Update(clase);
                _context.SaveChanges();
                return "";
            }
            return "No existe la clase,";
        }

        public List<AsistenciaResponse> ListarAsistencias(int IdCurso,DateTime Fecha)
        {
            List<AsistenciaResponse> lst = new List<AsistenciaResponse>();

           var asisntencias=_context.Asistencias.Include(x=> x.Clase)
                .Where(x => x.Clase.CursoId == IdCurso && x.Clase.FechaClase==Fecha).ToList();
            foreach(var a in asisntencias) {
                var p = _context.Cuenta.Include(p=> p.PersonaCuenta).SingleOrDefault(x => x.Id == a.CuentaId);

                var ar = new AsistenciaResponse() {
                    Ci=p.PersonaCuenta.Ci,
                    Nombre=p.PersonaCuenta.Nombre,
                    Apellido=p.PersonaCuenta.Apellido,
                    FechaAsistencia=a.Clase.FechaClase
                };
                lst.Add(ar);
            }
            return lst;
        }

        public List<AsistenciaResponse> ListarAsistenciaUsuario(int idUsuario,int IdCurso)
        {
            List<AsistenciaResponse> lst = new List<AsistenciaResponse>();
           var asistencias=_context.Asistencias.Include(x => x.Clase).Where(x=>x.CuentaId==idUsuario && x.Clase.CursoId==IdCurso).ToList();
            foreach (var a in asistencias) {
                var ar = new AsistenciaResponse() {
                    FechaAsistencia=a.Clase.FechaClase
                };
                lst.Add(ar);
            }
         
            return lst;
        }

        public List<Clase> ListarClases(int IdCurso){
           return  _context.Clases.Where(x=> x.CursoId==IdCurso).ToList();
        }

        public void BorrarClase(int IdClase) {
            var c=_context.Clases.Find(IdClase);
            _context.Clases.Remove(c);
            _context.SaveChanges();
        }

        public int GetClaseToday(int IdCurso,int usuarioId) {
            var hora = DateTime.Now;
            var data=_context.Clases.SingleOrDefault(x=> x.CursoId==IdCurso && x.Start<= hora && x.End>=hora);
            if (data == null) {
                return 0;//No es la Fecha
            }

            var asistencia = _context.Asistencias.SingleOrDefault(x => x.ClaseId == data.Id && x.CuentaId==usuarioId);
            if (asistencia != null) {
                return -1;//Ya marco la asistencia
            }
            return data.Id;//Puede Marcar Asistencia
        }
    }


}
