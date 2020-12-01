using Datos.Entity;
using Datos.Entity.GlobalesEntity;
using System.Collections.Generic;

namespace Presentacion.Models {
    public class AdministradorViewModel {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public virtual AdministradorFacultad AdminFacultad { get; set; }
        public virtual AdministradorUdelar AdminUdelar { get; set; }
        public virtual ICollection<Comunicado> Comunicados { get; set; }
        public string Tipo_Administrador { get; set; }
        public int Facultad { get; set; }
        public string Mensaje { get; set; }
        public string GoogleId { get; set; }

        public AdministradorViewModel() { }
        public List<Administrador> LstAdministrador = new List<Administrador>();
        public AdministradorViewModel(List<Administrador> admin) {
            foreach (var d in admin) {
                LstAdministrador.Add(d);
            }
        }

        public List<Facultad> LstFacultad = new List<Facultad>();
        public AdministradorViewModel(List<Facultad> facu) {
            foreach (var d in facu) {
                LstFacultad.Add(d);
            }
        }

        public AdministradorViewModel(string m) {
            Mensaje = m;
        }
    }
}
