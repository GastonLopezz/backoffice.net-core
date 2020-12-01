using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto
{
    public class MensajeRequest
    {
        public string Mensaje { get; set; }

        public int ChatId { get; set; }

        public int PersonaId { get; set; }
    }
}
