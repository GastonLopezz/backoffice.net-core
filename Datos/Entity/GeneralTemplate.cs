using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Entity {
    public class GeneralTemplate {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoTemplate { get; set; }
        public virtual IEnumerable<ModuloDefault> Modulos { get; set; }

    }
}
