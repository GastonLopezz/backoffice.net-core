using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Encuestas {
    public class EncuestaRequest {
        public string Titulo { get; set; }
        public string TipoEncuesta { get; set; }//Facultad o Curso
        public int FkId { get; set; }
        public string Facultad { get; set; }
        public int SeccionId { get; set; }
        public List<PreguntasRequest> LstPreguntas { get; set; }
        public List<RespuestaRequest>LstRespuestas { get; set; }
    }
}
