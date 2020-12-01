using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto;
using Negocio.Services.Interfaces;

namespace Presentacion.API_Rest
{
    [Route("api/docente")]
    [ApiController]
    //[Authorize]
    public class DocenteController : ControllerBase
    {

        private IDocenteService _docenteService;
        private IMultyTenancyService _nodoFacultad;

        public DocenteController(IDocenteService docente_service, IMultyTenancyService nodo)
        {
            _docenteService = docente_service;
            _nodoFacultad = nodo;
        }

        [HttpPost("confclave")]
        public IActionResult AsignarClaveMatriculacion(MatricularCursoResponse model)
        {
            _nodoFacultad.SeleccionarNodoFacultad(model.Facultad);//Establecemos el nodo al cual ir
            _docenteService.ConfigurarClaveMatriculacion(model.IdCurso, model.Clave, model.Opcion);
            return Ok();

        }

        [HttpGet("getclave")]
        public IActionResult GetClaveMatriculacion(string Facultad, int IdCurso)
        {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            return Ok(new { clave = _docenteService.getClave(IdCurso).ClaveMatriculacion });

        }
        [HttpGet("estudiantes")]
        public IActionResult EstudiantesDelCurso(string Facultad, int IdCurso)
        {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            var data = _docenteService.GetEstudiantesDelCurso(IdCurso);
            return Ok(data);

        }
        //Asignar docentes a la materia
        [HttpPost("asignardocente")]
        public IActionResult AsignarDocente(AsignacionDocenteRequest model)
        {
            _nodoFacultad.SeleccionarNodoFacultad(model.Facultad);//Establecemos el nodo al cual ir
            if (_docenteService.AsignarDocente(model.IdCurso, model.IdUserDocente, model.CiUserDocente))
            {
                return Ok(new { mensaje = "Docente asignado" });
            }
            return BadRequest(new { mensaje = "Error docente" });
        }
        //Borrar docente de la materia
        [HttpDelete("borrardocente")]
        public IActionResult BorrarDocenteAsignado(AsignacionDocenteRequest model)
        {
            _nodoFacultad.SeleccionarNodoFacultad(model.Facultad);//Establecemos el nodo al cual ir
            _docenteService.BorrarDocenteAsignado(model.IdCurso, model.IdUserDocente);
            return Ok(new { mensaje = "Docente Borrado" });

        }


        [HttpGet("docentes")]
        public IActionResult DocentesDelCurso(string Facultad, int IdCurso)
        {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);//Establecemos el nodo al cual ir
            return Ok(_docenteService.GetDocentesDelCurso(IdCurso));

        }

        [HttpPost("IngresarNotaFinal")]
        public IActionResult IngresarNotaFinal(NotaFinalRequest model)
        {
            try
            {
                _nodoFacultad.SeleccionarNodoFacultad(model.Facultad);
                int f=_nodoFacultad.ObtenerIdFacultad(model.Facultad);
                string res = _docenteService.IngresarNotaFinal(model.IdCurso, model.Ci, model.NotaFinal);
                if (string.IsNullOrEmpty(res))
                {
                    return Ok("Se ha ingresado la nota final");
                }
                return Ok(res);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObtenerNotaCurso")]
        public IActionResult ObtenerNotaCurso(int ci, int cursoId, string Facultad)
        {
            try
            {
                int FacultadId=_nodoFacultad.ObtenerIdFacultad(Facultad);
                string res = _docenteService.ObtenerNotaCurso(ci, cursoId, FacultadId);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObtenerNotasUsuario")]
        public IActionResult ObtenerNotasUsuaro(int ci, int FacultadId)
        {
            try
            {
                List<string> res = _docenteService.ObtenerNotasEstudiante(ci, FacultadId);
                if (res.Any())
                {
                    return Ok(res);
                }
                return BadRequest("Este usuario no tiene notas.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
