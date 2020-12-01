using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Evaluaciones
{
    public class CalificacionRequest
    {
        public List<CalificacionDesarrollo> CalificacionesDesarrollo { get; set; }
        public int CalificacionId { get; set; }
        public int EstudianteId { get; set; }
        public int EvaluacionId { get; set; }
        public string Facultad { get; set; }
    }
}
