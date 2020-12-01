using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.MongoDB.Clases
{
    public class Mensaje
    {
        [BsonId]
        public Guid Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Texto { get; set; }
        public int UsuarioEmisor { get; set; }
        public Mensaje()
        {
            FechaHora = DateTime.Now;
        }
    }
}
