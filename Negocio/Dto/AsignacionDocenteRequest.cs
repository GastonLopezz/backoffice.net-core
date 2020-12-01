using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto
{
    public class AsignacionDocenteRequest{
        public string Facultad { get; set; }
        public int IdCurso { get; set; }
        public int CiUserDocente { get; set; }
        public int IdUserDocente { get; set; }

    }
}
