using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Encuestas.Response {
    public class RespuestasEstadisticasResponse {
        public string Respuesta { get; set; }
        public int CantidadRespuestas { get; set; }
        public int Porcentaje { get; set; }
    }
}
