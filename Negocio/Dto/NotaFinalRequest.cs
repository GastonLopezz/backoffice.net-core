using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto
{
    public class NotaFinalRequest
    {
        public string Facultad { get; set; }
        public int Ci { get; set; }
        public int IdCurso { get; set; }
        public int NotaFinal { get; set; }
    }
}
