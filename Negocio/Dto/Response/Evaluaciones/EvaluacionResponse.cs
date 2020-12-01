using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response.Evaluaciones
{
    public class EvaluacionResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public bool ValidacionBedelia { get; set; }
        public string TipoEvaluacion { get; set; }
        public int CalificacionAprobacion { get; set; }
        public bool EsArchivo { get; set; }
     //   public int CalificacionExamen { get; set; }
        public List<DesarrolloResponse> desarrollos { get; set; }
        public List<VerdaderoFalsoResponse> vofs { get; set; }
    }
}
