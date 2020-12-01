using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Evaluaciones
{
    public class VerdaderoFalsoRequest
    {
        public string Pregunta { get; set; }//Pregunta
        public bool Opcion { get; set; }//Opcion Radio o Check si es check es multiple opcio,
        public int EvaluacionId { get; set; }
    }
}
