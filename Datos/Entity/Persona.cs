using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Datos.Entity {
    public class Persona {
        [Key]
        public int Id { get; set; }
        public int Ci { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public virtual ICollection<Cuenta> Cuentas { get; set; }

    }
}
