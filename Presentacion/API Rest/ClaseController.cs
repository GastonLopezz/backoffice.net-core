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
    [Route("api/clase")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private IClaseService _claseService;
        private IMultyTenancyService _multytenancyService;
        public ClaseController(IClaseService claseService, IMultyTenancyService ms)
        {
            _claseService = claseService;
            _multytenancyService = ms;
        }

        [HttpPost("AgregarClase")]
        public IActionResult AgregarClase([FromBody] ClaseRequest model)
        {
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(model.Facultad);
                string res = _claseService.NuevaClase(model.CursoId, model.FechaClase, model.Start, model.End);
                if (string.IsNullOrEmpty(res))
                {
                    return Ok(_claseService.ListarClases(model.CursoId));

                }
                return BadRequest(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("AgregarAsistencia")]
        public IActionResult AgregarAsistencia(int ClaseId, int UsuarioId, string Facultad,int CursoId)
        {
            try{
                _multytenancyService.SeleccionarNodoFacultad(Facultad);
                 _claseService.AgregarAsistencia(ClaseId, UsuarioId);
                int dev = _claseService.GetClaseToday(CursoId, UsuarioId);
                if (dev != 0) {
                    return Ok(new { mensaje = dev });
                }
                return Ok(new { mensaje = 0 });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Asistencias")]
        public IActionResult ListarAsistencias(string Facultad, int IdCurso, DateTime Fecha){
            try
            {
                _multytenancyService.SeleccionarNodoFacultad(Facultad);

                return Ok(_claseService.ListarAsistencias(IdCurso, Fecha));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("AsistenciasUsuario")]
        public IActionResult ListarAsistenciasUsuario(int UsuarioId,string Facultad,int IdCurso){
     
            try{
                _multytenancyService.SeleccionarNodoFacultad(Facultad);

                return Ok(_claseService.ListarAsistenciaUsuario(UsuarioId,IdCurso));

            }catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Clases")]
        public IActionResult ListarClases(string Facultad,int IdCurso){
            try{
                _multytenancyService.SeleccionarNodoFacultad(Facultad);

                return Ok(_claseService.ListarClases(IdCurso));
            }catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("borrarclase")]
        public IActionResult BorrarClase(string Facultad, int ClaseId, int IdCurso) {
            try {
                _multytenancyService.SeleccionarNodoFacultad(Facultad);
                _claseService.BorrarClase(ClaseId);
                return Ok(_claseService.ListarClases(IdCurso));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetClaseHoy")]
        public IActionResult GetClaseHoy(string Facultad, int IdCurso, int usuarioId) {
         _multytenancyService.SeleccionarNodoFacultad(Facultad);
           int dev=_claseService.GetClaseToday(IdCurso, usuarioId);
            if (dev!=0) {
                return Ok(new { mensaje = dev });
            }
            return Ok(new { mensaje = 0 });

        }




    }
}
