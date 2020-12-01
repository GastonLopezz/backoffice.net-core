using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity.GlobalesEntity {
    public class AdministradorFacultad  {
        [Key]
        public int AdministradorId { get; set; }

        public virtual Administrador Administrador { get; set; }
        public int FacultadId { get; set; }
        public Facultad FacultadAdministrador { get; set; }


    }
}
