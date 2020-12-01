using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.MongoDB.Clases
{
    public class Conversacion
    {
        [BsonId]
        public Guid Id { get; set; }
        public List<Mensaje> Mensajes { get; set; }
        public int UsuarioHost { get; set; }
        public int UsuarioGuest { get; set; }

        public Conversacion()
        {
            Mensajes = new List<Mensaje>();
        }
    }
}
