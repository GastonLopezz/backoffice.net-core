using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto {
    public class MensajeSMSRequest {
        public string Mensaje { get; set; }
        public string Numero { get; set; }
    }
}
