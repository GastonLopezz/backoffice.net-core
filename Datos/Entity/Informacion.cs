using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity {
    public class Informacion {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public int SeccionTemplateId { get;set;}
        public SeccionTemplate SeccionTemplate { get; set; }

    }
}
