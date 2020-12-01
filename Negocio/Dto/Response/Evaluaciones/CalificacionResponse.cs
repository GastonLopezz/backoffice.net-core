using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response.Evaluaciones
{
    public class CalificacionResponse
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public DateTime FechaPublicada { get; set; }
        public DateTime FechaCorregida { get; set; }
        public string EstadoCalificacion { get; set; }
        public string NombreEstudiante { get; set; }
        public string ApellidoEstudiante { get; set; }
        public string TipoEvaluacion { get; set; }
        public int EvaluacionId { get; set; }
        public string EvaluacionNombre { get; set; }
    }
}
