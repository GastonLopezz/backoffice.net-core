using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EvaluacionEntity
{
    public class Evaluacion
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public bool ValidacionBedelia { get; set; }
        public string TipoEvaluacion { get; set; }
        public bool EsArchivo { get; set; }
        public int CalificacionAprobacion { get; set; }
        public SeccionTemplate SeccionTemplate { get; set; }
        public int SeccionTemplateId { get; set; }

        public virtual ICollection<Calificacion> Calificaciones { get; set; }
        public virtual ICollection<VerdaderoFalso> VerdaderoFalso { get; set; }
        public virtual ICollection<Desarrollo> Desarrollo { get; set; }
    }
}
