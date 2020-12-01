using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Encuestas {
    public class AgregarRespuestaRequest {

        public int IdRespuesta { get; set; }
        public int CursoId { get; set; }
        public int UsuarioId { get; set; }
        public string Facultad { get; set; }
    }
}
