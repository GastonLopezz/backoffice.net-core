using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response.Evaluaciones
{
    public class VerdaderoFalsoResponse
    {
        public int Id { get; set; }
        public string Frase { get; set; }
        public bool MultipleOpcion { get; set; }
        public List<OpcionResponse> Opciones { get; set; }
    }
}
