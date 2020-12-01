using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto
{
    public class ForoRequest
    {
        public string Nombre { get; set; }
        public int IdForo { get; set; }
        public int SeccionId { get; set; }
        public string Facultad { get; set; }
        public bool Suscripcion { get; set; }
        
    }

}
