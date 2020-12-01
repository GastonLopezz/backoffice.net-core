using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.Dto {
    public class CreateUserRequest {

        [Required]
        public int Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }


        public string Usuario { get; set; }

        public string Password { get; set; }

        [Required]
        public string TipoCuenta { get; set; }

        [Required]
        public string Email { get; set; }
        public string Telefono { get; set; }

        [Required]
        public string Facultad { get; set; }

        public string GoogleId { get; set; }
        public string ImgUrl { get; set; }


    }
}
