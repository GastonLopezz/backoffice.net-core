using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Evaluaciones
{
    public class OpcionRequest
    {
        public string PreguntaAsociada { get; set; }
        public string Respuesta { get; set; }//Respuesta
        public bool Correcta { get; set; }//PreguntaAsociada
    }
}
