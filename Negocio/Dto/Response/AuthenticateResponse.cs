using System;
using System.Collections.Generic;
using System.Text;
using Datos.Entity;

namespace Negocio.Dto.Response {
    public class AuthenticateResponse {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoCuenta { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Cuenta user, string token) {
            Id = user.Id;
            Username = user.Usuario;
            Nombre = user.PersonaCuenta.Nombre;
            Apellido = user.PersonaCuenta.Apellido;
            TipoCuenta = user.TipoCuenta;
            Token = token;
        }
    }
}
