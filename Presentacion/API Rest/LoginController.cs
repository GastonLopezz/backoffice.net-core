using System;
using Negocio.Services.Password;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto;
using System.Linq;
using Negocio.Services.Interfaces;
using Negocio.Helpers;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Presentacion.Controllers.API_Rest {
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase {
        private IUserService _userService;
        private IFacultadesService _facultadesService;
        private IMultyTenancyService _nodoFacultad;

        public LoginController(IUserService userService, IFacultadesService fs, IMultyTenancyService nodo) {
            _userService = userService;
            _nodoFacultad = nodo;
            _facultadesService = fs;
        }

        [HttpGet("tipoauth")]
        public IActionResult TipoAuth(string Facultad) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            return Ok(new { autenticacion =_facultadesService.TipoAutenticacion() });
        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model) {
          _nodoFacultad.SeleccionarNodoFacultad(model.Facultad);//Establecemos el nodo al cual ir
          
            var response = _userService.Authenticate(model);

            if (response == null) {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(response);
            
        }
        [HttpPost("logingoogle")]
        public IActionResult AuthenticateGoogle(string googleId,string Facultad) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir

            var response = _userService.AuthenticateGoogle(googleId);

            if (response == null) {
                return BadRequest(new { message = "Usuario No Registrado" });
            }
            return Ok(response);

        }

        [HttpPost("register")]
        public IActionResult Register(CreateUserRequest model) {
            _nodoFacultad.SeleccionarNodoFacultad(model.Facultad);//Establecemos el nodo al cual ir
            var response = _userService.CrearCuenta(model);
            if (response == false) {
                return BadRequest(new { message = "Error al crear usuario" });

            }
            return Ok(new { message = "Usuario creado" });

        }

        [HttpPost("forgot")]
        public IActionResult ForgotPassword(string Facultad, string email){
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            if (_userService.EnviarMailForgotPassword(email)){
                return Ok(new { message = "Correo Enviado" });
            }
            return BadRequest(new { message = "Error email incorrecto" });

        }
        [HttpPost("updatepassword")]
        public IActionResult UpdatePassword(CuentaRequest model){
            _nodoFacultad.SeleccionarNodoFacultad(model.Facultad);
            if(_userService.ActualizarPassword(model.Email, model.Password, model.Password2)){
                return Ok(new { message = "Contraseña actulizada con exito" });
            }
            return BadRequest(new { message = "Error al actulizar contraseña" });
        }

        [Authorize]
        [HttpGet("getall")]
        public IActionResult GetAll(string Facultad) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            var users = _userService.GetAll();
            return Ok(users);     

        }
        [Authorize]

        [HttpGet("getci")]
        public IActionResult GetCi(int idUsuario,string Facultad) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            return Ok(_userService.GetCi(idUsuario));

        }


    }
}
