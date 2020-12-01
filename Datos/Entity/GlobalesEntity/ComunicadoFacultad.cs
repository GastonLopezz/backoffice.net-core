using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datos.Entity.GlobalesEntity {
    public class ComunicadoFacultad {

        [Key]
        public int Id { get; set; }
        public int ComunicadoId { get; set; }
        public Comunicado Comunicado { get; set; }

        public int FacultadId { get; set; }
        public Facultad Facultad { get; set; }

    }
}
