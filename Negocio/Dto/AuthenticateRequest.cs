using System.ComponentModel.DataAnnotations;

namespace Negocio.Dto {
    public class AuthenticateRequest {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string TipoCuenta { get; set; }
        [Required]
        public string Facultad { get; set; }

    }
}
