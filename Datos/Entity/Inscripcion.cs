using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity {
    public class Inscripcion {
        [DataType(DataType.Date)]
        public DateTime FechaInscripcion { get; set; }

        public bool? HabilitadoBedelia { get; set; }
        public bool Metriculado { get; set; }
        [Key, Column(Order = 1)]
        public int CursoId { get; set; }
        public virtual Curso CursoInscripcion { get; set; }

        [Key, Column(Order = 2)]
        public int EsudianteInscripcionId { get; set; }
        public Cuenta EsudianteInscripcion { get; set; }

    }
}
