using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response
{
    public class ArchivoEvaluacionResponse
    {
       public int Id { get; set; }
        public int EvaluacionId { get; set; }
        public string Nombre { get; set; }
        public int CuentaId { get; set; }
        public DateTime Creado { get; set; }
        public string Tipo { get; set; }
    }
}
