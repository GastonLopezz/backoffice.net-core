using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto
{
    public class ClaseRequest
    {
        public int CursoId { get; set; }

        public DateTime FechaClase { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Facultad { get; set; }
    }
}
