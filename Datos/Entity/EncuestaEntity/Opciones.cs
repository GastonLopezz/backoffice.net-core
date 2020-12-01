using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EncuestaEntity {
   public class Opciones {
        [Key]
        public int Id { get; set; }
        public string Respuesta { get; set; }
        public int PreguntaId { get; set; }
        public virtual Preguntas Pregunta { get; set; }
    }
}
