using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EvaluacionEntity
{
    public class Calificacion
    {
        [Key]
        public int Id { get; set; }
        public int Nota { get; set; }
        public DateTime FechaPublicada { get; set; }
        public DateTime FechaCorregida { get; set; }
        public string EstadoCalificacion { get; set; }

        public Cuenta Estudiante { get; set; }
        public int EstudianteId { get; set; }
        public Evaluacion Evaluacion { get; set; }
        public int EvaluacionId { get; set; }


    }
}
