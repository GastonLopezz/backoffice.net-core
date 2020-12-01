using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.GlobalesEntity {

    public class Facultad {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string Url { get; set; }
        public string Logo { get; set; }//LookANDFeel
        public string TipoNav { get; set; }//LookANDFeel
        public string ColorNav { get; set; }//LookANDFeel
        public string TipoAutenticacion { get; set; }

        public string NombreBD { get; set; }

        public virtual ICollection<ComunicadoFacultad> ComunicadoFacultad { get; set; }

    }
}
