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
    [Route("api/curso")]
    [ApiController]
    public class CursoController : ControllerBase {

        private ICursoService _cursoService;
        private IMultyTenancyService _nodoFacultad;

        public CursoController(ICursoService curso_service, IMultyTenancyService nodo) {
            _cursoService = curso_service;
            _nodoFacultad = nodo;
        }

        //[Authorize]
        [HttpPost("matricularme")]
        public IActionResult Matricularme([FromBody] CursoMatriculacionRequest model){
            _nodoFacultad.SeleccionarNodoFacultad(model.Facultad);//Establecemos el nodo al cual ir
            int idFacultad=_nodoFacultad.ObtenerIdFacultad(model.Facultad);//Establecemos el nodo al cual ir

            //EndPoint Bedelias aca..
            return Ok(new { mesage= _cursoService.MatricularmeACurso(model.IdCurso, model.ClaveMatriculacion, model.IdUsuario, idFacultad) });
         }

        [HttpGet("cursos")]
        public IActionResult CursosDicatos(string Facultad) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            return Ok(_cursoService.ObtenerCursos());
        }
        [Authorize]
        [HttpGet("miscursos")]
        public IActionResult MisCursos(string Facultad, int usuarioId) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            return Ok(_cursoService.MisCursos(usuarioId));
        }

        [Authorize]
        [HttpGet("miscursosdocente")]
        public IActionResult MisCursosDocente(string Facultad, int usuarioId) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            return Ok(_cursoService.MisCursosDocente(usuarioId));
        }

        [HttpGet("getcurso")]
        public IActionResult GetCurso(string Facultad, int cursoId) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            return Ok(_cursoService.GetDataCurso(cursoId));
        }
        [HttpGet("getnombre")]
        public IActionResult getnombre(string Facultad, int cursoId) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            return Ok(new { nombre = _cursoService.GetNombreCurso(cursoId)});
        }
        [HttpGet("deleteseccion")]
        public IActionResult DeleteModulo(string Facultad, int seccionId,int cursoId) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            _cursoService.BorrarSeccion(seccionId);
            return Ok(_cursoService.GetDataCurso(cursoId));
        }
        [HttpGet("seccion")]
        public IActionResult AddModulo(string Facultad, string seccion, int cursoId) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            _cursoService.AgregarSeccion(cursoId,seccion);
            return Ok(_cursoService.GetDataCurso(cursoId));
        }

        [HttpGet("comunicados")]
        public IActionResult ComunicadosCurso(string Facultad, int cursoId) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            return Ok(_cursoService.ListarComunicadoCurso(cursoId));
        }
    }
}
