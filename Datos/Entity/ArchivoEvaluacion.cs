using Datos.Entity.EvaluacionEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity
{
    public class ArchivoEvaluacion
    {
        [Key]
        public int Id { get; set; }
        public Evaluacion Evaluacion { get; set; }
        public int EvaluacionId { get; set; }

        public string Nombre { get; set; }

        public Cuenta Cuenta { get; set; }
        public int CuentaId { get; set; }

        public byte[] Archivo { get; set; }

        public DateTime Creado { get; set; }

        public string Tipo { get; set; }
    }
}
