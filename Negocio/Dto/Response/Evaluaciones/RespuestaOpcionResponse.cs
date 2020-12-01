using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response.Evaluaciones
{
    public class RespuestaOpcionResponse
    {
        public int Id { get; set; }
        public string Frase { get; set; }
        public RespuestaVoFResponse respuesta { get; set; }
    }
}
