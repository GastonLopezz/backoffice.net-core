using Microsoft.AspNetCore.Mvc;
using Negocio.Services.Interfaces;
using System;

namespace Presentacion.API_Rest
{
    [Route("api/Calendario")]
    [ApiController]
    public class CalendarioController : ControllerBase
    {
        private ICalendarioService _calendarioService;
        private IMultyTenancyService _multytenancyService;
        public CalendarioController(ICalendarioService calendarioService, IMultyTenancyService ms)
        {
            _calendarioService = calendarioService;
            _multytenancyService = ms;
        }

        [HttpPost("NuevoEvento")]
        public IActionResult NuevoEvento(int cursoId, string titulo, string facultad, DateTime fecha){
            _multytenancyService.SeleccionarNodoFacultad(facultad);
            string res = _calendarioService.NuevoEvento(cursoId, titulo, facultad, fecha);
            if (string.IsNullOrEmpty(res))
            {
                return Ok("Se ha agregado un nuevo evento al calendario");
            }
            return BadRequest(res);
        }

        [HttpPost("BorrarEvento")]
        public IActionResult BorrarEvento(int cursoId,DateTime fecha, string facultad)
        {
            _multytenancyService.SeleccionarNodoFacultad(facultad);
            string res = _calendarioService.BorrarEvento(cursoId,fecha);
            if (string.IsNullOrEmpty(res))
            {
                return Ok("Se ha agregado un nuevo evento al calendario");
            }
            return BadRequest(res);
        }

        [HttpGet("Eventos")]
        public IActionResult ObtenerEventos(string facultad,int cursoId)
        {
            _multytenancyService.SeleccionarNodoFacultad(facultad);

            return Ok(_calendarioService.ObtenerEventos(cursoId));
        }

        [HttpGet("get")]
        public IActionResult ObtenerEvento(string facultad, int cursoId,DateTime fecha) {
            _multytenancyService.SeleccionarNodoFacultad(facultad);
            return Ok(new { mensaje =_calendarioService.ObtenerEvento(cursoId, fecha) });
        }
    }
}
