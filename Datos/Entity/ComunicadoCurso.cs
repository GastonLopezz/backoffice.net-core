using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity {
    public class ComunicadoCurso {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaPublicacion{get;set;}
        public int CursoId { get; set; }
        public Curso ComunicadoAlCurso { get; set; }
      //  public int DocenteId { get; set; }
        //public Cuenta Docente { get; set; }
     //   public int AdministradorId { get; set; }
    }
}
