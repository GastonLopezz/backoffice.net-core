using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Services.Interfaces;

namespace Presentacion.API_Rest {
    [Route("api/facultad")]
    [ApiController]
    public class FacultadController : ControllerBase {
        private IFacultadesService _facultadesService;
        private IMultyTenancyService _nodoFacultad;

        public FacultadController(IFacultadesService fs, IMultyTenancyService nodo) {
            _nodoFacultad = nodo;
            _facultadesService = fs;
        }

        [HttpGet("comunicados")]
        public IActionResult Comunicados(string Facultad) {
            return Ok(new { comunicados = _facultadesService.ComunicadoFacultades(Facultad)});
        }
        [HttpGet("facultades")]
        public IActionResult Facultades(string Facultad) {
            return Ok(new { facultades = _facultadesService.ListarFacultades() });
        }

        [HttpGet("get")]
        public IActionResult FacultadData(string Facultad) {
           
            return Ok(_facultadesService.DatosFacultad(Facultad));
        }

        [HttpGet("getid")]
        public IActionResult FacultadId(string Facultad) {

            return Ok(_nodoFacultad.ObtenerIdFacultad(Facultad));
        }
    }
}
