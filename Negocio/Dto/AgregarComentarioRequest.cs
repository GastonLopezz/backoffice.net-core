using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto
{
    public class AgregarComentarioRequest
    {
        public int IdForo { get; set; }
        public int IdCuenta { get; set; }
        public int IdDiscusion { get; set; }
        public string Comentario { get; set; }
        public string Facultad { get; set; }
    }
}
