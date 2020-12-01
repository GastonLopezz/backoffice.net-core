using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Encuestas.Response {
   public class PreguntasEstadisticaResponse {
        public string Pregunta { get; set; }
        public string Tipo { get; set; }
        public List<RespuestasEstadisticasResponse> LstRespuestas { get; set; }

    }
}
