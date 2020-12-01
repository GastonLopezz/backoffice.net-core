using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity.EncuestaEntity {
    public class EncuestaCurso {
        [Key, Column(Order = 1)]
        public int EncuestaId { get; set; }
        public virtual Encuesta Encuesta { get; set; }
        [Key, Column(Order = 2)]
        public int SeccionTemplateId { get; set; }
        public virtual SeccionTemplate SeccionTemplate { get; set; }

        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
