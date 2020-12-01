using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.Dto.Response.Mongo
{
    public class ConversacionResponse
    {
        public List<MensajeResponse> Mensajes { get; set; }
        [Required]
        public int UsuarioHost { get; set; }
        [Required]
        public int UsuarioGuest { get; set; }
    }
}
