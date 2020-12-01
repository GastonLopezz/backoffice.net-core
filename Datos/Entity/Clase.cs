using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity
{
    [Table("Clases")]
    public class Clase
    {
        [Key]
        public int Id { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public DateTime FechaClase { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
