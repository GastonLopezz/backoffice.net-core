using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EncuestaEntity {
    public class Preguntas {
        [Key]
        public int Id { get; set; }
        public string Frase { get; set; }
        public string TipoCheck { get; set; }//Redio o Checkbox
        public int EncuestaId { get; set; }
        public virtual Encuesta Encuesta { get; set; }
        public virtual IEnumerable<Opciones> Opciones { get; set; }
     
    }
}
