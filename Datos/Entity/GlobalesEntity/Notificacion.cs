using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity.GlobalesEntity
{
    [Table("Notificaciones")]
    public class Notificacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FechaCreada { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Mensaje { get; set; }

        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; } 

    }
}
