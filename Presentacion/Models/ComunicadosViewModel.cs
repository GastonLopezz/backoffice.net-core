using Datos.Entity;
using Datos.Entity.GlobalesEntity;
using System;
using System.Collections.Generic;

namespace Presentacion.Models {
    public class ComunicadosViewModel {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha_Publicacion { get; set; }

        public int AdministradorId { get; set; }
        public Administrador AdminPublicador { get; set; }
        public virtual ICollection<ComunicadoFacultad> ComunicadoFacultad { get; set; }
        public ComunicadosViewModel() {    }

        public ComunicadosViewModel(string m) {
            Texto = m;
        }

       
    }
}
