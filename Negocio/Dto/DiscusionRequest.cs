using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto
{
    public class DiscusionRequest
    {
        public int IdForo { get; set; }
        public int IdCuenta { get; set; }
        public string Titulo { get; set; }
        public string Facultad { get; set; }
    }
}
