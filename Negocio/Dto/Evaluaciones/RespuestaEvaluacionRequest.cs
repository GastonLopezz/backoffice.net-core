using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Evaluaciones
{
    public class RespuestaEvaluacionRequest
    {
        public int EvaluacionId { get; set; }
        public string Facultad { get; set; }
        public int EstudianteId { get; set; }
        public List<RespuestaDesarrolloRequest> desarrollos { get; set; }
        public List<RespuestaVofRequest> vofs { get; set; }
    }
}
