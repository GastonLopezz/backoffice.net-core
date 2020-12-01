using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.Dto.Response.Mongo
{
    public class MensajeResponse
    {
        [Required]
        public string Texto { get; set; }
        [Required]
        public int UsuarioEmisor { get; set; }
        [Required]
        public DateTime FechaEnviado { get; set; }
        [Required]
        public string Facultad { get; set; }
    }
}
