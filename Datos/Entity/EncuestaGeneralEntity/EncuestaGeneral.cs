using Datos.Entity.GlobalesEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EncuestaGeneralEntity
{
    public class EncuestaGeneral
    {
        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public virtual IEnumerable<PreguntasGeneral> Preguntas { get; set; }
    }
}
