using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Encuestas {
    public class RespuestaRequest {
        public string Respuesta { get; set; }
        public string PreguntaAsociada { get; set; }
    }
}
