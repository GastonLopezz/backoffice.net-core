using Datos.Entity.EncuestaEntity;
using Datos.Entity.GlobalesEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;

namespace Datos.Entity {
  
    public class Curso {
       [Key]
       public int Id { get; set; }
       public string Nombre { get; set; }
       public int Creditos { get; set; }
       public string ClaveMatriculacion { get; set; }
       public int YearDiactado { get; set; }
       public string TipoCurso { get; set; }
       public string DictaCurso { get; set; }
       public string Informacion { get; set; }
        [DataType(DataType.Date)]
       public DateTime FechaLimiteInscripcion { get; set; }
       public int NotaMinimaAprobacion { get; set; }
       public int NotaMaximaAprobacion { get; set; }
       public int? NotaMinimaExamen { get; set; }
       public int? NotaMaximaExamen { get; set; }
  

       public virtual ICollection<SeccionTemplate> Secciones { get; set; }
       //public virtual ICollection<EncuestaCurso> EncuestaCursos { get; set; }

    }
}
