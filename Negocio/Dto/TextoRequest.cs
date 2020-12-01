using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto {
    public class TextoRequest {
        public int SeccionId { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Facultad { get; set; }

    }
}
