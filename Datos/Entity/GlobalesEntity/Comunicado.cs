using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.GlobalesEntity {
    public class Comunicado {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime FechaPublicacion { get; set; }
       
        public int AdministradorId { get; set; }
        public Administrador AdminPublicador { get; set; }
        public virtual ICollection<ComunicadoFacultad> ComunicadoFacultad { get; set; }

    }
}
