using Negocio.Dto.Evaluaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto
{
    public class EvaluacionRequest
    {
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoEvaluacion { get; set; }
        public int CalificacionAprobacion { get; set; }
        public bool EsArchivo { get; set; }
        public int SeccionId { get; set; }
        public List<DesarrolloRequest> desarrollos { get; set; }
        public List<VerdaderoFalsoRequest> vofs { get; set; }
        public List<OpcionRequest> opciones { get; set; }
        public string ArchivoBase64 { get; set; }
        public int UsuarioId { get; set; }
    }
}
