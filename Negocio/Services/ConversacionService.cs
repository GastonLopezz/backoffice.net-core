using Datos.Context;
using Datos.Entity.GlobalesEntity;
using Datos.MongoDB;
using Datos.MongoDB.Clases;
using Microsoft.EntityFrameworkCore;
using Negocio.Dto.Mongo;
using Negocio.Dto.Response.Mongo;
using Negocio.Services.Interfaces;
using Negocio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Services
{
    public class ConversacionService : IConversacionService
    {
        private readonly ContextoParticular _context;
        private readonly ContextoGeneral _contextoGeneral;
        private readonly string collection = "Conversacion";

        public ConversacionService(ContextoParticular ctx, ContextoGeneral ctxg)
        {
            _context = ctx;
            _contextoGeneral = ctxg;
        }
        private Conversacion nuevaConversacion(int UsuarioHost, int UsuarioGuest, string nombreFacultad)
        {
            Conversacion conv = new Conversacion()
            {
                UsuarioGuest = UsuarioGuest,
                UsuarioHost = UsuarioHost,
                Mensajes = new List<Datos.MongoDB.Clases.Mensaje>()
            };
            Mongodb mdb = new Mongodb(nombreFacultad);
            mdb.InsertRecord(collection, conv);
            return conv;
        }
        public ConversacionResponse obtenerConversacionResponse(int UsuarioHost, int UsuarioGuest, string facultadbd)
        {
            //RETORNA UNA CONVERSACION EN CASO DE ESTAR CREADA UNA QUE TENGA A AMBOS USUARIOS (EN AMBOS ROLES)
            //CREA Y RETORNA UNA EN CASO DE NO HABER

            //FALTA VERIFICAR QUE EXISTA EL USUARIO EN LA BASE DE DATOS RELACIONAL

            Conversacion conv = obtenerConversacion(UsuarioHost, UsuarioGuest, facultadbd);
            List<MensajeResponse> listMens = new List<MensajeResponse>();
            if (conv.Mensajes.Count() > 0)
            {
                foreach (Datos.MongoDB.Clases.Mensaje mens in conv.Mensajes)
                {
                    listMens.Add(new MensajeResponse()
                    {
                        Texto = mens.Texto,
                        UsuarioEmisor = mens.UsuarioEmisor,
                        FechaEnviado = mens.FechaHora
                    });
                }
            }
            return new ConversacionResponse()
            {
                Mensajes = listMens,
                UsuarioHost = conv.UsuarioHost,
                UsuarioGuest = conv.UsuarioGuest
            };

        }
        private Conversacion obtenerConversacion(int UsuarioHost, int UsuarioGuest, string facultadbd)
        {
            //RETORNA UNA CONVERSACION EN CASO DE ESTAR CREADA UNA QUE TENGA A AMBOS USUARIOS (EN AMBOS ROLES)
            //CREA Y RETORNA UNA EN CASO DE NO HABER

            //FALTA VERIFICAR QUE EXISTA EL USUARIO EN LA BASE DE DATOS RELACIONAL
            var facultad = _contextoGeneral.Facultad.SingleOrDefault(f => f.Url == facultadbd);
            if (facultad != null)
            {
                Mongodb mdb = new Mongodb(facultad.NombreBD);
                List<Conversacion> listConv = mdb.LoadRecord<Conversacion>(collection).ToList();

                foreach (Conversacion conv in listConv)
                {
                    if ((conv.UsuarioGuest.Equals(UsuarioGuest) &&
                        conv.UsuarioHost.Equals(UsuarioHost)) ||
                        (conv.UsuarioGuest.Equals(UsuarioHost) &&
                        conv.UsuarioHost.Equals(UsuarioGuest)))
                    {
                        return conv;
                    }
                }
                return nuevaConversacion(UsuarioHost, UsuarioGuest, facultad.NombreBD);
            }
            else
            {
                throw (new Exception("No se encuentran datos de facultad con ese nombre"));
            }
        }

        public bool enviarMensaje(MensajeRequest mensajeRequest)
        {

            Conversacion conversacion = obtenerConversacion(mensajeRequest.UsuarioEmisor, mensajeRequest.UsuarioReceptor, mensajeRequest.Facultad);
            Mongodb mdb = new Mongodb(_contextoGeneral.Facultad.SingleOrDefault(x => x.Url == mensajeRequest.Facultad).NombreBD);
            conversacion.Mensajes.Add(new Datos.MongoDB.Clases.Mensaje()
            {
                Texto = mensajeRequest.Texto,
                UsuarioEmisor = mensajeRequest.UsuarioEmisor,
            });
            mdb.UpsertRecord(collection, conversacion.Id, conversacion);
            PusherUtil.Enviar(PusherUtil.canal, PusherUtil.evento, conversacion.Mensajes.LastOrDefault());
            return true;
        }
        public List<BasicConversacionResponse> listarConversacionesUsuario(int UsuarioId, string facultadbd) {
            var facultad = _contextoGeneral.Facultad.SingleOrDefault(f => f.Url == facultadbd);
            Mongodb mdb = new Mongodb(facultad.NombreBD);
            List<Conversacion> listConv = mdb.LoadRecord<Conversacion>(collection).ToList();
            List<BasicConversacionResponse> lb = new List<BasicConversacionResponse>();
            foreach (Conversacion conv in listConv) {
                if ((conv.UsuarioGuest == UsuarioId) || (conv.UsuarioHost == UsuarioId)) {
                    var cuenta_host = _context.Cuenta
                        .Include(z => z.PersonaCuenta)
                        .SingleOrDefault(x => x.Id == conv.UsuarioHost);
                    var cuenta_guest = _context.Cuenta
                        .Include(z => z.PersonaCuenta)
                        .SingleOrDefault(x => x.Id == conv.UsuarioGuest);

                    lb.Add(new BasicConversacionResponse() {
                        UsuarioHost = conv.UsuarioHost,
                        NombreHost = cuenta_host.PersonaCuenta.Nombre + " " + cuenta_host.PersonaCuenta.Apellido,
                        UsuarioGuest = conv.UsuarioGuest,
                        NombreGuest = cuenta_guest.PersonaCuenta.Nombre + " " + cuenta_guest.PersonaCuenta.Apellido,

                    });
                }
            }
            return lb;
        }
     public List<PersonasSelectResponse> ObtenerersonasChat() {
            List<PersonasSelectResponse> Lst = new List<PersonasSelectResponse>();
            var cuentas=_context.Cuenta.ToList(); 
            
            foreach( var c in cuentas) {
                var p=_context.Persona.SingleOrDefault(x => x.Id == c.PersonaId);
                var psr=new PersonasSelectResponse() {
                    Id=c.Id,
                    Nombre=p.Nombre,
                    Apellido=p.Apellido,
                    TipoUsuario=c.TipoCuenta
                };
                Lst.Add(psr);
            }
            return Lst;
        }
        }
    
}
