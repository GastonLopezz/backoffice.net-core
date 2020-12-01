using Datos.Entity.EncuestaEntity;
using Datos.Entity.EvaluacionEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity
{
    public class SeccionTemplate
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Visible { get; set; }
        public int Prioridad { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public virtual ICollection<EncuestaCurso> EncuestaCursos { get; set; }

        public virtual ICollection<Informacion> Informaciones { get; set; }

        public virtual ICollection<Material> Materiales { get; set; }
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; }

        public virtual ICollection<Foro> Foros { get; set; }


    }
}
