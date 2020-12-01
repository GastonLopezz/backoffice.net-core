using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity
{
    public class Calendario
    {
        [Key]
        public int Id { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        
    }
}
