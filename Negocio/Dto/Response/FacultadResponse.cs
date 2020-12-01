using Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negocio.Dto.Response {
    public class FacultadResponse {
        public int Id { get; set; }
        public string Url { get; set; }
        public List<CursoResponse> Cursos { get; set; }
        public string NombreFacultad { get; set; }
        public virtual ICollection<Curso> Curso { get; set; }
    }
}
