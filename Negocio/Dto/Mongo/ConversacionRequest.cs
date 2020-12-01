using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.Dto.Mongo
{
    public class ConversacionRequest
    {
        public List<MensajeRequest> Mensajes { get; set; }
        [Required]
        public int UsuarioHost { get; set; }
        [Required]
        public int UsuarioGuest { get; set; }
    }
}
