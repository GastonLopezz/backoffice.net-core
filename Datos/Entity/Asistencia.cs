using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity
{
    public class Asistencia
    {
        [Key]
        public int Id { get; set; }

        public int ClaseId { get; set; }
        public Clase Clase { get; set; }

        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}
