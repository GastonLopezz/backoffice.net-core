using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response.Evaluaciones
{
    public class RespuestasResponse
    {
        public List<RespuestaDesarrolloResponse> desarrollos { get; set; }
        public List<RespVerdaderoFalsoResponse> vofs { get; set; }
    }
}
