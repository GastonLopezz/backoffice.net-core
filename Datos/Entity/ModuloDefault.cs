using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity {
    public class ModuloDefault {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Prioridad { get; set; }

        public int TemplateId { get; set; }
        public virtual GeneralTemplate Tamplate { get; set; }
    }
}
