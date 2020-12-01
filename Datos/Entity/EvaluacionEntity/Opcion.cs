using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EvaluacionEntity
{
    public class Opcion
    {
        [Key]
        public int Id { get; set; }
        public string Frase { get; set; }
        public bool Correcta { get; set; }

        public VerdaderoFalso VerdaderoFalso { get; set; }
        public int VerdaderoFalsoId { get; set; }
    }
}
