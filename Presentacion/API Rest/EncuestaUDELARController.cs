using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto.Encuestas;
using Negocio.Services.Interfaces;

namespace Presentacion.API_Rest
{
    [Route("api/encuestaG")]
    [ApiController]
    public class EncuestaUDELARController : ControllerBase
    {
        private IEncuestaUDELARService _encuestaService;

        public EncuestaUDELARController(IEncuestaUDELARService es)
        {
            _encuestaService = es;
        }


        [HttpPost("add")]
        public IActionResult CrearEncuesta(EncuestaGeneralRequest model)
        {
            try
            {
                _encuestaService.AddEncuesta(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        

        [HttpGet("encuestas")]
        public IActionResult ObtenerEncuestasFacultad()
        {
            try
            {
                return Ok(_encuestaService.ObtenerEncuestas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

        [HttpGet("encuestarespoonder")]
        public IActionResult ObtenerDatosParaResponder(int encuestaId)
        {
            try
            {
                return Ok(_encuestaService.ObtenerEncuestaParaResponder(encuestaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("responder")]
        public IActionResult Responder(ResponderEncuestaGeneralRequest model)
        {
            try
            {
                _encuestaService.ResponderEncuesta(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
