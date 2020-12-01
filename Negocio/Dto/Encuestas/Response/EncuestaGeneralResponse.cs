using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Encuestas.Response
{
    public class EncuestaGeneralResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<PreguntasResponse> LstPreguntas { get; set; }
    }
}
