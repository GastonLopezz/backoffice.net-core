using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EvaluacionEntity
{
    public class Desarrollo
    {
        [Key]
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public int PuntajeAprobacion { get; set; }
        public virtual ICollection<RespuestaDesarrollo> Respuestas { get; set; }

        public Evaluacion Evaluacion { get; set; }
        public int EvaluacionId { get; set; }
    }
}
