using Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Models {
    public class PersonaViewModel {
        public int Id { get; set; }
        public int Ci { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public virtual ICollection<Cuenta> Persona { get; set; }

        public PersonaViewModel() { }
        public List<Persona> LstPersona = new List<Persona>();
        public PersonaViewModel(List<Persona> Persona) {
            foreach (var d in Persona) {
                LstPersona.Add(d);
            }
        }
    }
}
