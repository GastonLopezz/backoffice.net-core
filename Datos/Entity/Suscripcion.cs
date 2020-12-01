using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity
{
    [Table("Suscripciones")]
    public class Suscripcion
    {
        [Key]
        public int Id { get; set; }

        public int ForoId { get; set; }
        public Foro Foro { get; set; }

        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}
