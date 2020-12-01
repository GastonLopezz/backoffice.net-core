using Datos.Entity;
using Negocio.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Models {
    public class CursoViewModel {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public bool Publico { get; set; }
        public int Creditos { get; set; }
        public string Clave_Matriculacion { get; set; }
        public int Year_Diactado { get; set; }
        public string Tipo_Curso { get; set; }
        public string Dicta_Curso { get; set; }
        public string Informacion { get; set; }
        public DateTime Fecha_Limite_Inscripcion { get; set; }
        public int Nota_Minima_Aprobacion { get; set; }
        public int Nota_Maxima_Aprobacion { get; set; }
        public int? Nota_Minima_Examen { get; set; }
        public int? Nota_Maxima_Examen { get; set; }
        public int Comunicados { get; set; }
        public string Comunicado { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Fecha_Publicacion { get; set; }

        public CursoViewModel() { }

        public List<Curso> LstCurso = new List<Curso>();
        public CursoViewModel(List<Curso> curso) {
            foreach (var c in curso) {
                LstCurso.Add(c);
            }
        }

        public List<ComunicadoResponse> LstComCur = new List<ComunicadoResponse>();
        public CursoViewModel(List<ComunicadoResponse> comfac) {
            foreach (var cf in comfac) {
                LstComCur.Add(cf);
            }
        }

        public List<ComunicadoCurso> LstComunicadoC = new List<ComunicadoCurso>();
        public CursoViewModel(List<ComunicadoCurso> comunicadoCurso) {
            foreach (var f in comunicadoCurso) {
                LstComunicadoC.Add(f);
            }
        }
    }
}
