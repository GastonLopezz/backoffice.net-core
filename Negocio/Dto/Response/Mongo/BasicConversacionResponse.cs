using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.Dto.Mongo
{
    public class BasicConversacionResponse
    {
        [Required]
        public int UsuarioHost { get; set; }
        [Required]
        public int UsuarioGuest { get; set; }
        public string NombreHost { get; set; }

        public string NombreGuest { get; set; }
    }
}
