using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity
{
    [Table("Comentarios")]
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FechaCreado { get; set; }

        [Required]
        public string Texto { get; set; }

        public int CuentaId { get; set; }

        public Cuenta Cuenta { get; set; }

        public int DiscusionId { get; set; }

        public Discusion Discusion { get; set; }

        public int ForoId { get; set; }

        public Foro Foro { get; set; }

        public List<Comentario> Comentarios { get; set; }
    }
}
