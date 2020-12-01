using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto
{
    public class CursoMatriculacionRequest{
        public int IdUsuario { get; set; }
        public string Facultad { get; set; }
        public int IdCurso { get; set; }
        public string ClaveMatriculacion { get; set; }
    }
}
