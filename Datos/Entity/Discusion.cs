using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity
{
    [Table("Discusiones")]
    public class Discusion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public DateTime FechaCreado { get; set; }

        public int CuentaId { get; set; }

        public Cuenta Cuenta { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }

        public int ForoId { get; set; }

        public Foro Foro { get; set; }
    }
}
