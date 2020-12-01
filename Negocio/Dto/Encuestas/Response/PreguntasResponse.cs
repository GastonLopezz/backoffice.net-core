using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Encuestas.Response {
   public class PreguntasResponse {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string TipoPregunta { get; set; }
        public List<OpcionesResponse> LstOpciones { get; set; }

    }
}
