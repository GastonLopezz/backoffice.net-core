using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response.Evaluaciones
{
    public class RespuestaDesarrolloResponse
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Puntaje { get; set; }
    }
}
