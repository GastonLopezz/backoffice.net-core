using Datos.Entity;
using Datos.Entity.GlobalesEntity;
using Negocio.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto {
    public class FacultadRequest {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string Url { get; set; }
        public byte[] Logo { get; set; }//LookANDFeel
        public string TipoAutenticacion { get; set; }
        public int TemplateId { get; set; }

        public ICollection<CursoResponse> LstCursoResponse { get; set; }
        public FacultadRequest() { }

        public FacultadRequest(Facultad f) {
            Nombre = f.Nombre;
            Abreviatura = f.Abreviatura;
            Url = f.Url;
            //Logo = f.Logo;
            TipoAutenticacion = f.TipoAutenticacion;
            TemplateId = 1;

        }
    }
}
