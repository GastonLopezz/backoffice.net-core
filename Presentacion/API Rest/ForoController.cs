using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto;
using Negocio.Services.Interfaces;

namespace Presentacion.API_Rest
{
    [Route("api/Foro")]
    [ApiController]
    public class ForoController : ControllerBase
    {

        private IForoService _foroService;
        private IMultyTenancyService _multytenancyService;
        private IDocenteService _docenteService;
        public ForoController(IForoService foroService, IMultyTenancyService ms, IDocenteService docenteService)
        {
            _foroService = foroService;
            _multytenancyService = ms;
            _docenteService = docenteService;
        }

        [HttpGet("GetForo")]
        public IActionResult GetForo(int idForo, string facultad)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(facultad);
                return Ok(_foroService.GetForo(idForo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObtenerForos")]
        public IActionResult ObtenerForos(string facultad, int idCurso)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(facultad);
                return Ok(_foroService.ObtenerForos(idCurso));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("NuevoForo")]
        public IActionResult NuevoForo([FromBody] ForoRequest model)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(model.Facultad);
                string res = _foroService.NuevoForo(model.Nombre, model.SeccionId, model.Suscripcion);
                if (string.IsNullOrEmpty(res))
                {
                    return Ok("Se ha agregado el foro: " + model.Nombre);
                }
                return BadRequest(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("EliminarForo")]
        public IActionResult EliminarForo(int idForo, string facultad)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(facultad);
                string res = _foroService.EliminarForo(idForo);
                if (string.IsNullOrEmpty(res))
                {
                    return Ok("Se ha eliminado el foro.");
                }
                return BadRequest(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PublicarDiscusion")]
        public IActionResult PublicarDiscusion([FromBody] DiscusionRequest model)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(model.Facultad);
                string res = _foroService.PublicarDiscusion(model.IdForo, model.IdCuenta, model.Titulo);
                if (string.IsNullOrEmpty(res))
                {
                    return Ok("Se ha publicado una nueva discusion.");
                }
                return BadRequest(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ModificarForo")]
        public IActionResult ModificarForo([FromBody] ForoRequest model)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(model.Facultad);
                string res = _foroService.ModificarForo(model.IdForo, model.SeccionId, model.Suscripcion, model.Nombre);
                if (string.IsNullOrEmpty(res))
                {
                    return Ok("Se ha modificado el foro");
                }
                return BadRequest(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Suscribirse")]
        public IActionResult SuscribirseAForo(int idForo, int idUsuario, string facultad)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(facultad);
                string res = _foroService.SuscribirseAForo(idForo, idUsuario);
                if (string.IsNullOrEmpty(res))
                {
                    return Ok("Se ha suscripto al foro");
                }
                return BadRequest(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Suscripciones")]
        public IActionResult ListarSuscripciones(string facultad)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(facultad);
                return Ok(_foroService.ListarSuscripciones());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
