using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity.EncuestaGeneralEntity
{
    public class RespuestasGeneral
    {
        [Key, Column(Order = 1)]
        public int OpcionId { get; set; }
        public virtual OpcionesGeneral Opcion { get; set; }

        [Key, Column(Order = 2)]
        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}
