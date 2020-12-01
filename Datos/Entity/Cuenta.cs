using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity {
    public class Cuenta {

        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Passwd { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string NumeroTelefono { get; set; }
        public string TipoCuenta { get; set; }
        public int PersonaId { get; set; }
        public Persona PersonaCuenta { get; set; }

        public virtual CuentaGoogle CuentaGoogle { get; set; }
    }
}
