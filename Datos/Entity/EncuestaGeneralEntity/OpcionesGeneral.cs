using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EncuestaGeneralEntity
{
    public class OpcionesGeneral
    {
        [Key]
        public int Id { get; set; }
        public string Respuesta { get; set; }
        public int PreguntaGeneralId { get; set; }
        public virtual PreguntasGeneral PreguntaGeneral { get; set; }
    }
}
