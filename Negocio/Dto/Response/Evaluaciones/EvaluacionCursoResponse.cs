using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response.Evaluaciones {
    public class EvaluacionCursoResponse {
        public int EvaluacionId { get; set; }
        public int EstudianteId { get; set; }
        public string EvaluacionTitulo { get; set; }
        public int NotaEstudiante { get; set; }
        public int CiEstudiante { get; set; }
        public string NombreEstudiante { get; set; }
        public string ApellidoEstudiante { get; set; }
        public bool EsArchivo { get; set; }
        public string NombreArchivo { get; set; }

        public string TipoEvaluacion { get; set; }
        public int CalificacionAprobacion { get; set; }
        public string EstadoCalifiacion { get; set; }

    }
}
