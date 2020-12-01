using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity.GlobalesEntity {
    public class AdministradorUdelar {
        [Key]
        public int AdministradorId { get; set; }
        public virtual Administrador Administrador { get; set; }
    }
}
