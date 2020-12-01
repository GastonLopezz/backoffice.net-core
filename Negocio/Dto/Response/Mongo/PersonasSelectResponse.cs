using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Negocio.Dto.Response.Mongo {
    public class PersonasSelectResponse {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoUsuario { get; set; }

    }
}
