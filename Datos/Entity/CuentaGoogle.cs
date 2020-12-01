using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Entity {
    public class CuentaGoogle {

            [Key]
            public int Id { get; set; }
            public string GoogleId { get; set; }
            public string ImgUrl { get; set; }

            public int CuentaId { get; set; }
            public virtual Cuenta CuentaPersona { get; set; }
        }
    }



