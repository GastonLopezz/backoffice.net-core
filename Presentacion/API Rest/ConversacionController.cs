using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Negocio.Dto.Mongo;
using Negocio.Dto.Response.Mongo;
using Negocio.Services.Interfaces;

namespace Presentacion.API_Rest
{
    [Route("api/chat")]
    [ApiController]
    //[Authorize]
    public class ConversacionController : ControllerBase
    {
        private IConversacionService _conversacionService;
        private IMultyTenancyService _multytenancyService;
        public ConversacionController(IConversacionService conversacionService, IMultyTenancyService ms)
        {
            _conversacionService = conversacionService;
            _multytenancyService = ms;
        }

        [HttpPost("enviarMensaje")]
        public IActionResult EnviarMensaje([FromBody] MensajeRequest mensajeRequest)//aca creo la conversacion y enviao el mesanje
        {
            try
            {
                bool ok = _conversacionService.enviarMensaje(mensajeRequest);
                if (ok)
                {
                    return Ok(new { message = "Se envio mensaje a " + mensajeRequest.UsuarioReceptor });
                }
                return BadRequest(new { error = "Error: No se pudo enviar el mensaje, revise los datos e intentelo de nuevo" });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }

        }
        [HttpGet("obtenerConversacion")]
        public IActionResult obtenerConversacion(int usuarioHost, int usuarioGuest, string facultad)//Obtengo los mensajes...
        {
            try
            {
                ConversacionResponse cr = _conversacionService.obtenerConversacionResponse(usuarioHost, usuarioGuest, facultad);
                return Ok(cr);
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }

        }

        [HttpGet("conversacionesUsuario")]
        public IActionResult obtenerConversacion(int usuarioId, string facultad)//Obtengo mis covnersaciones
        {
            try
            {
                List<BasicConversacionResponse> lb = _conversacionService.listarConversacionesUsuario(usuarioId, facultad);
                return Ok(new { conversaciones = lb });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message, trace = e.StackTrace });
            }

        }

        [HttpGet("selectpersonas")]
        public IActionResult ObtenerPersonasSelect(string Facultad) {
            _multytenancyService.SeleccionarNodoFacultad(Facultad);
            return Ok(_conversacionService.ObtenerersonasChat());
        }
    }
}
