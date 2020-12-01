using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity.GlobalesEntity {
    public class Administrador {
  
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Passwd { get; set; }
        public string Salt { get; set; }
        public virtual AdministradorFacultad AdminFacultad { get; set; }
        public virtual AdministradorUdelar AdminUdelar { get; set; }
        public virtual ICollection<Comunicado> Comunicados { get; set; }
        
    }
}
