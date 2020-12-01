using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.Dto
{
    public class CuentaRequest {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string TipoUsuario { get; set; }
        [Required]
        public string Facultad { get; set; }
    }
}
