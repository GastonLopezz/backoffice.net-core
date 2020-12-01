using Datos.Entity;
using Datos.Entity.GlobalesEntity;
using System.Collections.Generic;

namespace Presentacion.Models {
    public class MensajeViewModel {

        public string Mensaje { get; set; }

        public MensajeViewModel(string m) {
            Mensaje = m;
        }
    }
}