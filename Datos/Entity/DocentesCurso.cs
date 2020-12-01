using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity {
    public class DocentesCurso {
        [Key, Column(Order = 1)]
        public int DocenteId { get; set; }
        public virtual Cuenta Docente { get; set; }

        [Key, Column(Order = 2)]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public bool Escargado { get; set; }  //encargado del curso si es docente
    }
}
