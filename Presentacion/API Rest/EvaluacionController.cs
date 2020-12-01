using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto;
using Negocio.Dto.Evaluaciones;
using Negocio.Dto.Response.Evaluaciones;
using Negocio.Services.Interfaces;

namespace Presentacion.API_Rest
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluacionController : ControllerBase
    {
        IEvaluacionService _evaluacion;
        IMultyTenancyService _nodoFacultad;
        public EvaluacionController(IEvaluacionService evaluacion, IMultyTenancyService nodoFacultad)
        {
            _evaluacion = evaluacion;
            _nodoFacultad = nodoFacultad;
        }

        [HttpPost("agregar")]
        public IActionResult agregarEvaluacion(string facultad, [FromBody] EvaluacionRequest evaluacionRequest) {
            try
            {
                _nodoFacultad.SeleccionarNodoFacultad(facultad);
                string res = _evaluacion.agregarEvaluacion(evaluacionRequest);
                if (string.IsNullOrEmpty(res))
                {
                    return Ok("Se agrego Evaluacion exitosamente");
                }
                return BadRequest(res);
            } catch (Exception e)
            {
                return BadRequest(new { error = "Algo salio mal", message = e.Message, trace = e.StackTrace });
            }
        }

        [HttpPost("responder")]
        public IActionResult responderEvaluacion([FromBody] RespuestaEvaluacionRequest respuesta)
        {
            try
            {
                _nodoFacultad.SeleccionarNodoFacultad(respuesta.Facultad);
                _evaluacion.responderEvaluacion(respuesta);

                return Ok(new { exito = "Se agrego la respuesta exitosamente" });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "Algo salio mal", source = e.Source, message = e.Message, trace = e.StackTrace });
            }
        }
        [HttpPost("calificar")]
        public IActionResult calificar(CalificacionRequest notasDesarrollo){
            try{
                _nodoFacultad.SeleccionarNodoFacultad(notasDesarrollo.Facultad);
                int idCalificacion=_evaluacion.ObtenerIdCalifacion(notasDesarrollo.EvaluacionId, notasDesarrollo.EstudianteId);
                notasDesarrollo.CalificacionId = idCalificacion;
                _evaluacion.calificar(notasDesarrollo);

                return Ok(new { exito = "Se califico la evaluacion"});
            }
            catch (Exception e){
                return BadRequest(new { error = "Algo salio mal", source = e.Source, message = e.Message, trace = e.StackTrace });
            }
        }
        [HttpGet("get")]
        public IActionResult obtenerEvaluacionesCurso(int SeccionId, string Facultad)
        {
            try
            {
                _nodoFacultad.SeleccionarNodoFacultad(Facultad);
                List<EvaluacionResponse> evaluaciones = _evaluacion.obtenerEvaluacionesSeccion(SeccionId);

                return Ok(new { evaluaciones });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "Algo salio mal", source = e.Source, message = e.Message, trace = e.StackTrace });
            }
        }
        [HttpGet("getevaluacion")]
        public IActionResult obtenerEvaluacionCurso(int EvaluacionId, string Facultad) {
            try {
                _nodoFacultad.SeleccionarNodoFacultad(Facultad);
                return Ok(_evaluacion.obtenerEvaluacion(EvaluacionId));
            } catch (Exception e) {
                return BadRequest(new { error = "Algo salio mal", source = e.Source, message = e.Message, trace = e.StackTrace });
            }
        }

        [HttpGet("cuenta/calificacion/get")]
        public IActionResult obtenerCalificacionesUsuario(int CuentaId, string Facultad)
        {
            try
            {
                _nodoFacultad.SeleccionarNodoFacultad(Facultad);
                List<CalificacionResponse> cr = _evaluacion.obtenerCalificacionesUsuario(CuentaId);

                return Ok(new { calificaciones = cr });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "Algo salio mal", source = e.Source, message = e.Message, trace = e.StackTrace });
            }
        }
        [HttpGet("calificacion/get")]
        public IActionResult obtenerCalificacionesEvaluacion(int EvaluacionId, string Facultad)
        {
            try
            {
                _nodoFacultad.SeleccionarNodoFacultad(Facultad);
                List<CalificacionResponse> cr = _evaluacion.obtenerCalificacionesEvaluacion(EvaluacionId);

                return Ok(new { calificaciones = cr });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "Algo salio mal", source = e.Source, message = e.Message, trace = e.StackTrace });
            }
        }

        [HttpGet("respuesta/get")]
        public IActionResult obtenerRespuestasEvaluacion(int EstudianteId, int EvaluacionId, string Facultad)
        {
            try
            {
                _nodoFacultad.SeleccionarNodoFacultad(Facultad);
                RespuestasResponse rr = _evaluacion.obtenerRespuestasEvaluacion(EvaluacionId,EstudianteId);

                return Ok(new { Respuestas = rr });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = "Algo salio mal", source = e.Source, message = e.Message, trace = e.StackTrace });
            }
        }

        [HttpGet("fechalimite")]
        public IActionResult fechaLimiteEvaluacion(int EvaluacionId, string Facultad) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);

            if (_evaluacion.FechaLimiteEvaluacion(EvaluacionId)) {
                return Ok(new { mensaje = true });
            }
            return Ok(new { mensaje = false });
        }
        [HttpGet("evaluacionescurso")]
        public IActionResult EvaluacionesByCurso(int CursoId, string Facultad) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);
            return Ok(_evaluacion.ObtenerEvaluacionesDelCurso(CursoId));
        }
        [HttpPost("editarnota")]
        public IActionResult EditarNotaEvaluacion(string Facultad,int idEvaluacion, int idEstudiante,int Nota,int CursoId) {
            _nodoFacultad.SeleccionarNodoFacultad(Facultad);
            _evaluacion.EditarCalifacion(idEvaluacion, idEstudiante, Nota);
            return Ok(_evaluacion.ObtenerEvaluacionesDelCurso(CursoId));
        }

    }
}
