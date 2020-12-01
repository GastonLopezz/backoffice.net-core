using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EncuestaGeneralEntity
{
    public class PreguntasGeneral
    {
        [Key]
        public int Id { get; set; }
        public string Frase { get; set; }
        public string TipoCheck { get; set; }//Redio o Checkbox
        public int EncuestaGeneralId { get; set; }
        public virtual EncuestaGeneral EncuestaGeneral { get; set; }
        public virtual IEnumerable<OpcionesGeneral> Opciones { get; set; }
    }
}
