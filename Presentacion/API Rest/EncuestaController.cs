using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto;
using Negocio.Dto.Encuestas;
using Negocio.Services.Interfaces;

namespace Presentacion.API_Rest {
    [Route("api/encuesta")]
    [ApiController]
    //[Authorize]
    public class EncuestaController : ControllerBase {

        private IMultyTenancyService _nodoFacultad;
        private IEncuestaService _encuestaService;

        public EncuestaController(IEncuestaService es, IMultyTenancyService nodo) {
            _encuestaService = es;
            _nodoFacultad = nodo;
        }

       
        [HttpPost("add")]
        public void CrearEncuesta(EncuestaRequest model) {
            _nodoFacultad.SeleccionarNodoFacultad(model.Facultad);//Establecemos el nodo al cual ir
            _encuestaService.AddEncuesta(model);

        }
        [HttpGet("encuestaCurso")]
        public IActionResult ObtenerEncuestasCurso(string facultad,int cursoId) {
            _nodoFacultad.SeleccionarNodoFacultad(facultad);//Establecemos el nodo al cual ir
           return Ok( _encuestaService.ObtenerEncuestasCurso(cursoId));
        }

        [HttpGet("encustaFacultad")]
        public IActionResult ObtenerEncuestasFacultad(string facultad)
        {
            _nodoFacultad.SeleccionarNodoFacultad(facultad);//Establecemos el nodo al cual ir
            return Ok(_encuestaService.ObtenerEncuestasFacultad(facultad));
        }

        [HttpGet("encuestarespoonder")]
        public IActionResult ObtenerDatosParaResponder(string facultad, int encuestaId) {
            _nodoFacultad.SeleccionarNodoFacultad(facultad);//Establecemos el nodo al cual ir
            return Ok(_encuestaService.ObtenerEncuestaParaResponder(encuestaId));
        }
        [HttpPost("responder")]
        public IActionResult Responder(ResponderEncuestaRequest model) {
            _nodoFacultad.SeleccionarNodoFacultad(model.Facultad);//Establecemos el nodo al cual ir

            _encuestaService.ResponderEncuesta(model);
            return Ok();
        }
        [HttpGet("estadistica")]
        public IActionResult Estadisicas(string facultad, int encuestaId, int cursoId) {
            _nodoFacultad.SeleccionarNodoFacultad(facultad);//Establecemos el nodo al cual ir

            return Ok(_encuestaService.EstadisticasCurso(cursoId,encuestaId));
        }

    }
}
