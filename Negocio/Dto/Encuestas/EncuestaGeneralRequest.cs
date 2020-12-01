using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Encuestas
{
    public class EncuestaGeneralRequest
    {
        public string Titulo { get; set; }
        public int SeccionId { get; set; }
        public List<PreguntasRequest> LstPreguntas { get; set; }
        public List<RespuestaRequest> LstRespuestas { get; set; }
    }
}
