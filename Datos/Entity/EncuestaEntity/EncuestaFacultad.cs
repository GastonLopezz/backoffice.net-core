using Datos.Entity.GlobalesEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity.EncuestaEntity
{
    public class EncuestaFacultad
    {
        [Key, Column(Order = 1)]
        public int EncuestaId { get; set; }
        public virtual Encuesta Encuesta { get; set; }

        [Key, Column(Order = 2)]
        public int SeccionTemplateId { get; set; }
        public virtual SeccionTemplate SeccionTemplate { get; set; }

        public int FacultadId { get; set; }
        public virtual Facultad Facultad { get; set; }
    }
}
