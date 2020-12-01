using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response {
    public class AsistenciaResponse {

        public int Ci { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public DateTime FechaAsistencia { get; set; }
    }
}
