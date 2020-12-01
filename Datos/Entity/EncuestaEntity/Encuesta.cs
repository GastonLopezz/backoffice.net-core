using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EncuestaEntity {
   public class Encuesta {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoEncuesta { get; set; }//Facultad o Curso
        public virtual IEnumerable<Preguntas> Preguntas { get; set; }
        public virtual EncuestaCurso EncuestaCurso { get; set; }
        public virtual EncuestaFacultad EncuestaFacultad { get; set; }

    }
}
