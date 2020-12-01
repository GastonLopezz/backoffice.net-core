using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EvaluacionEntity
{
    public class VerdaderoFalso
    {
        [Key]
        public int Id { get; set; }
        public string Frase { get; set; }
        public bool MultipleOpcion { get; set; }
        public virtual ICollection<Opcion> OpcionesVoF { get; set; }

        public virtual ICollection<RespuestaVoF> Respuestas { get; set; }
        public Evaluacion Evaluacion { get; set; }
        public int EvaluacionId { get; set; }

    }
}
