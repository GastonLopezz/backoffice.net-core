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
    public class DiscusionService : IDiscusionService
    {
        private ContextoParticular _context;
        public DiscusionService(ContextoParticular ctx)
        {
            _context = ctx;
        }

        public string NuevaDiscusion(int idCuenta, int idForo, string titulo)
        {
            string ret = "";
            try
            {
                Cuenta cuenta = _context.Cuenta.First(c => c.Id == idCuenta);
                Foro f = _context.Foros.First(f => f.Id == idForo);
                if (cuenta != null && f != null) {
                    Discusion d = new Discusion()
                    {
                        Comentarios = new List<Comentario>(),
                        Cuenta = cuenta,
                        Titulo = titulo,
                        CuentaId = cuenta.Id,
                        FechaCreado = DateTime.Now,
                        Foro = f,
                        ForoId = f.Id
                    };
                    _context.Discusiones.Add(d);
                    _context.SaveChanges();
                    return ret;
                }
                return ret = "No existe la cuenta y/o el foro";
            }
            catch (Exception ex)
            {
                return ret = ex.Message;
            }
        }

        public string EliminarDiscusion(int idForo, int idDiscusion)
        {
            string ret = "";
            try
            {
                Foro f = _context.Foros.First(f => f.Id == idForo);
                Discusion d = _context.Discusiones.First(d => d.Id == idDiscusion);
                if(f != null && d != null)
                {
                    foreach(var item in d.Comentarios)
                    {
                        _context.Comentarios.Remove(item);
                    }
                    _context.Discusiones.Remove(d);
                    _context.SaveChanges();
                    return ret;
                }
                return ret = "No existe el foro o la discusion que se intenta eliminar";
            }
            catch (Exception ex)
            {
                return ret = ex.Message;
            }
        }

        public string AgregarComentario(int idForo, int idDiscusion, int idCuenta, string comentario)
        {
            string ret = "";
            try
            {
                Foro f = _context.Foros.Find(idForo);
                Discusion d = _context.Discusiones.Find(idDiscusion);
                Cuenta cuenta = _context.Cuenta.Find(idCuenta);
                if(f != null && d != null && cuenta != null)
                {
                    Comentario c = new Comentario()
                    {
                        Cuenta = cuenta,
                        CuentaId = cuenta.Id,
                        Texto = comentario,
                        FechaCreado = DateTime.Now,
                        Comentarios = new List<Comentario>(),
                        Discusion = d,
                        DiscusionId = d.Id,
                        ForoId = f.Id,
                        Foro = f
                    };
                    _context.Comentarios.Add(c);
                    _context.SaveChanges();
                    return ret;
                }
                return ret = "No existe el foro o la discusion o la cuenta";
            }
            catch (Exception ex)
            {
                return ret = ex.Message;
            }
        }

        public List<Discusion> ObtenerDiscusiones(int idForo)
        {
            return _context.Discusiones.Where(x=>x.ForoId == idForo).ToList();
        }

        public Discusion GetDiscusion(int idDiscusion)
        {
            return _context.Discusiones.Find(idDiscusion);
        }

        public List<ComentarioResponse> ObtenerComentariosDeDiscusion(int idForo, int idDiscusion)
        {
            //List<string> lista = new List<ComentarioResponse>();
            try
            {
                Foro foro = _context.Foros.Find(idForo);
                if (foro != null)
                {
                    List<ComentarioResponse> respuesta = new List<ComentarioResponse>();
                    foreach(var comentario in _context.Comentarios.Where(n => n.DiscusionId == idDiscusion).ToList())
                    {
                        var cuenta = _context.Cuenta.Include(c=>c.PersonaCuenta).SingleOrDefault(c => c.Id == comentario.CuentaId);
                        var c = new ComentarioResponse
                        {
                            Fecha = comentario.FechaCreado,
                            NombreUsuario = cuenta.PersonaCuenta.Nombre + " " + cuenta.PersonaCuenta.Apellido,
                            Texto = comentario.Texto
                        };
                        respuesta.Add(c);
                    }

                    
                    return respuesta;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Comentario> ObtenerComentarios(int idDiscusion)
        {
            try
            {
                return _context.Comentarios.Where(x=>x.DiscusionId==idDiscusion).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }







    }
}
