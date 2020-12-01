using Datos.Entity;
using Datos.Entity.GlobalesEntity;
using Negocio.Dto;
using Negocio.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Models {
    public class FacultadViewModel {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string Url { get; set; }
        public string Logo { get; set; }//LookANDFeel
        public string Tipo_Autenticacion { get; set; }
        public int Template { get; set; }
        public string Tipo { get; set; }//LookANDFeel
        public string Color { get; set; }//LookANDFeel
        public int Comunicados { get; set; }
        public string Comunicado { get; set; }
        public string Texto { get; set; }
        public string Fecha_Publicacion { get; set; }

        public FacultadViewModel() {       }

        public List<Facultad> LstFacultad = new List<Facultad>();
        public  FacultadViewModel(List<Facultad> facu) { 
            foreach(var f in facu) {
                LstFacultad.Add(f);
            }
        }

        public List<CursoResponse> LstCursos = new List<CursoResponse>();
        public FacultadViewModel(List<CursoResponse> curso) {
            foreach (var c in curso) {
                LstCursos.Add(c);
            }
        }

        public List<FacultadResponse> LstFacu = new List<FacultadResponse>();
        public FacultadViewModel(List<FacultadResponse> fac) {
            foreach (var f in fac) {
                LstFacu.Add(f);
            }
        }

        public List<ComunicadoResponse> LstComFacu = new List<ComunicadoResponse>();
        public FacultadViewModel(List<ComunicadoResponse> comfac) {
            foreach (var cf in comfac) {
                LstComFacu.Add(cf);
            }
        }
    }
}
