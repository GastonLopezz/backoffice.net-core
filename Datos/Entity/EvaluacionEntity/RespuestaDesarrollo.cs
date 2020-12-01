using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity.EvaluacionEntity
{
    public class RespuestaDesarrollo
    {
        [Key]
        public int Id { get; set; }
        public string Respuesta { get; set; }
        public int Puntaje { get; set; }
        public int EstudianteId { get; set; }
        public Cuenta Estudiante { get; set; }
        public Desarrollo Desarrollo { get; set; }
        public int DesarrolloId { get; set; }
    }
}
