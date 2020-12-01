using Datos.Context;
using Datos.Entity;
using Microsoft.EntityFrameworkCore;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Services
{
    public class ForoService : IForoService
    {
        private ContextoParticular _context;
        public ForoService(ContextoParticular ctx)
        {
            _context = ctx;
        }

        public string NuevoForo(string nombre, int seccionId, bool suscripcion)
        {
            string ret = "";
            try
            {
                var SeccionTemplate = _context.SeccionTemplate.Find(seccionId);
                if (SeccionTemplate != null)
                {
                    Foro f = new Foro()
                    {
                        Nombre = nombre,
                        Discusiones = new List<Discusion>(),
                        Seccion = SeccionTemplate,
                        SeccionTemplateId = SeccionTemplate.Id,
                        Suscripcion = suscripcion
                    };
                    _context.Foros.Add(f);
                    _context.SaveChanges();
                    return ret;
                }
                return ret = "No existe la seccion";
            }
            catch (Exception ex)
            {
                return ret = ex.Message;
            }

        }

        public string EliminarForo(int idForo)
        {
            string ret = "";
            try
            {
                Foro f = _context.Foros.Find(idForo);
                if (f != null)
                {
                    _context.Foros.Remove(f);
                    _context.SaveChanges();
                    return ret;
                }
                return ret = "El foro que intenta eliminar no existe.";
            }
            catch (Exception ex)
            {
                return ret = ex.Message;
            }
        }

        public string ModificarForo(int id, int seccionId, bool suscripcion, string nombre)
        {
            string ret = "";
            try
            {
                Foro f = _context.Foros.Find(id);
                SeccionTemplate seccion = _context.SeccionTemplate.Find(seccionId);
                if (f != null && seccion != null)
                {
                    f.Nombre = nombre;
                    f.Seccion = seccion;
                    f.SeccionTemplateId = seccion.Id;
                    f.Suscripcion = suscripcion;
                    _context.Foros.Update(f);
                    _context.SaveChanges();
                    return ret = "Se ha modificado el foro.";
                }
                return ret = "El foro que intenta modificar no existe";

            }
            catch (Exception ex)
            {
                return ret = ex.Message;
            }
        }

        public List<Foro> ObtenerForos(int idCurso)
        {
            return _context.Foros
                .Where(x => x.Seccion.CursoId == idCurso)
                .ToList();
        }

        public string PublicarDiscusion(int idForo, int idCuenta, string titulo)
        {
            string ret = "";
            try
            {
                Foro f = _context.Foros.First(f => f.Id == idForo);
                Cuenta cuenta = _context.Cuenta.First(c => c.Id == idCuenta);
                if (f != null && cuenta != null)
                {
                    var discusion = new Discusion()
                    {
                        Cuenta = cuenta,
                        FechaCreado = DateTime.Now,
                        CuentaId = cuenta.Id,
                        Titulo = titulo,
                        Comentarios = new List<Comentario>(),
                        Foro = f,
                        ForoId = f.Id
                    };
                    _context.Discusiones.Add(discusion);
                    _context.SaveChanges();
                    return ret;
                }
                return ret = "No existe la cuenta";

            }
            catch (Exception ex)
            {
                return ret = ex.Message;
            }

        }

        public Foro GetForo(int idForo)
        {
            if (_context.Foros.Any())
            {
                return _context.Foros.First(f => f.Id == idForo);
            }
            return null;
        }

        public string SuscribirseAForo(int idForo, int idUsuario)
        {
            Foro f = _context.Foros.Find(idForo);
            Cuenta c = _context.Cuenta.Find(idUsuario);
            if (f != null && c != null)
            {
                Suscripcion s = new Suscripcion()
                {
                    Foro = f,
                    ForoId = f.Id,
                    Cuenta = c,
                    CuentaId = c.Id
                };
                _context.Suscripciones.Add(s);
                _context.SaveChanges();
                return "";
            }
            return "No se encuentra el foro o el estudiante";
        }

        public List<Suscripcion> ListarSuscripciones()
        {
            return _context.Suscripciones.ToList();
        }
    }
}
