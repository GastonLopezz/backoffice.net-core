using Datos.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto.Response {
    public class PersonaCuentaResponse {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoCuenta { get; set; }
        public string Username { get; set; }
        public bool Encargado { get; set; }

        public PersonaCuentaResponse(int id,string nombre,string apellido, string username, string tipoCuenta,bool encargado) {
            Id = id;
            Username = username;
            Nombre = nombre;
            Apellido = apellido;
            TipoCuenta = tipoCuenta;
            Encargado = encargado;


        }

    }
}
