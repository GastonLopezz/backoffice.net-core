using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto;
using Negocio.Dto.Response;
using Negocio.Services.Interfaces;

namespace Presentacion.API_Rest
{
    [Route("api/Discusiones")]
    [ApiController]
    public class DiscusionController : ControllerBase
    {
        private IDiscusionService _discusionService;
        private IMultyTenancyService _multytenancyService;
        public DiscusionController(IDiscusionService discusionService, IMultyTenancyService multyTenancyService)
        {
            _discusionService = discusionService;
            _multytenancyService = multyTenancyService;
        }

        [HttpPost("AgregarComentario")]
        public IActionResult AgregarComentario([FromBody] AgregarComentarioRequest model)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(model.Facultad);
                string res = _discusionService.AgregarComentario(model.IdForo, model.IdDiscusion, model.IdCuenta, model.Comentario);
                if (string.IsNullOrEmpty(res))
                {
                    return Ok("Se agrego el comentario a la discusion");
                }
                return BadRequest(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("NuevaDiscusion")]
        public IActionResult NuevaDiscusion(int idCuenta, int idForo, string titulo, string facultad)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(facultad);
                string res = _discusionService.NuevaDiscusion(idCuenta, idForo, titulo);
                if (string.IsNullOrEmpty(res))
                {
                    return Ok("Se ha creado una nueva discusion");
                }
                return BadRequest(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Discusion")]
        public IActionResult GetDiscusion(int idDiscusion, string facultad)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(facultad);
                var discusion = _discusionService.GetDiscusion(idDiscusion);
                if(discusion != null)
                {
                    return Ok(discusion);
                }
                return BadRequest("No se encuentra la discusion.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObtenerDiscusiones")]
        public IActionResult ObtenerDiscusiones(string facultad, int idForo)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(facultad);
                var lista = _discusionService.ObtenerDiscusiones(idForo);
                if (lista.Any())
                {
                    return Ok(lista);
                }
                return BadRequest("No hay discusiones para mostrar");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ComentariosDiscusion")]
        public IActionResult ObtenerComentariosDiscusion(int idForo, int idDiscusion, string facultad)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(facultad);
                List<ComentarioResponse> lista = _discusionService.ObtenerComentariosDeDiscusion(idForo, idDiscusion);
                if (lista != null && lista.Count > 0)
                {
                    return Ok(lista);
                }
                return BadRequest("No hay comentarios para esta discusion");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("Eliminar")]
        public IActionResult EliminarDiscusion(int idForo, int idDiscusion, string facultad) 
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(facultad);
                string res = _discusionService.EliminarDiscusion(idForo, idDiscusion);
                if (string.IsNullOrEmpty(res))
                {
                    return Ok("Se ha eliminado la discusion");
                }
                return BadRequest(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Comentarios")]
        public IActionResult ObtenerComentarios(string facultad, int idForo)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(facultad);
                var lista = _discusionService.ObtenerComentarios(idForo);
                if(lista != null && lista.Count > 0)
                {
                    return Ok(lista);
                }
                return Ok("La lista esta vacia");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
