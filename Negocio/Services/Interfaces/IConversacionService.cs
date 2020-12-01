using Negocio.Dto.Mongo;
using Negocio.Dto.Response.Mongo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces
{
    public interface IConversacionService
    {
        public bool enviarMensaje(MensajeRequest mensajeRequest);
        public ConversacionResponse obtenerConversacionResponse(int UsuarioHost, int UsuarioGuest, string facultadbd);
        public List<BasicConversacionResponse> listarConversacionesUsuario(int UsuarioId, string facultadbd);
        public List<PersonasSelectResponse> ObtenerersonasChat();
    }
}
