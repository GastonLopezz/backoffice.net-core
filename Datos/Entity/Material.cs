using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Entity {
    public class Material {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public int SeccionId { get; set; }
        public SeccionTemplate Seccion { get; set; }
    }
}
