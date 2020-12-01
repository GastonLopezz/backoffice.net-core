using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Encuestas
{
    public class ResponderEncuestaGeneralRequest
    {
        public int UsuarioId { get; set; }
        public List<RespuestaAddRequestCheck> LstRespuestasCheck { get; set; }
        public List<RespuestaAddRequestRadio> LstRespuestasRadio { get; set; }
    }
}
