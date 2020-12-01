using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response {
    public class ComunicadoResponse {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
