using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity
{
    [Table("Foros")]
    public class Foro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int SeccionTemplateId { get; set; }
        public SeccionTemplate Seccion { get; set; }

        public bool Suscripcion { get; set; }
        public ICollection<Discusion> Discusiones { get; set; }

    }
}
