using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity.EncuestaEntity {
    public class Respuestas {
        [Key, Column(Order = 1)]
        public int OpcionId { get; set; }
        public virtual Opciones Opcion { get; set; }

        [Key, Column(Order = 2)]
        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }

    }
}
