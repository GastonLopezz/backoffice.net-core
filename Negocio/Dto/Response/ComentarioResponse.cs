using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response
{
    public class ComentarioResponse
    {
        public string Texto { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
