using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Evaluaciones
{
    public class DesarrolloRequest
    {
        public string Pregunta { get; set; }
        public int PuntajeAprobacion { get; set; }
        public int EvaluacionId { get; set; }
    }
}
