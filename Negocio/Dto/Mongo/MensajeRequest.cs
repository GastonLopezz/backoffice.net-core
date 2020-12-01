using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.Dto.Mongo
{
    public class MensajeRequest
    {
        [Required]
        public string Texto { get; set; }
        [Required]
        public int UsuarioEmisor { get; set; }
        [Required]
        public int UsuarioReceptor { get; set; }
        [Required]
        public string Facultad { get; set; }
    }
}
