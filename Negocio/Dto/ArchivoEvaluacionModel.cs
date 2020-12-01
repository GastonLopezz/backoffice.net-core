using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto
{
    public class ArchivoEvaluacionModel
    {
        
        public int EvaluacionId { get; set; }

        public string NombreArchivo { get; set; }//NombreArchivo

        public int CuentaId { get; set; }

        public string Facultad { get; set; }

        public string ArchivoBase64 { get; set; }
    }
}
