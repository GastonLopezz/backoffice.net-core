using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EvaluacionEntity
{
    public class RespuestaVoF
    {
        [Key]
        public int Id { get; set; }
        public bool Eleccion { get; set; }
        public int EstudianteId { get; set; }
        public Cuenta Estudiante{ get; set; }

        public Opcion Opcion { get; set; }
        public int OpcionId { get; set; }

        public VerdaderoFalso VerdaderoFalso { get; set; }
        public int VerdaderoFalsoId { get; set; }
    }
}
