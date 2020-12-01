using Negocio.Dto;
using Negocio.Dto.Evaluaciones;
using Negocio.Dto.Response.Evaluaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces
{
    public interface IEvaluacionService
    {
        string agregarEvaluacion(EvaluacionRequest evaluacionRequest);
        void calificar(CalificacionRequest notasDesarrollo);
        List<EvaluacionResponse> obtenerEvaluacionesSeccion(int idSeccion);
        List<CalificacionResponse> obtenerCalificacionesUsuario(int idCuenta);
        List<CalificacionResponse> obtenerCalificacionesEvaluacion(int EvaluacionId);
        RespuestasResponse obtenerRespuestasEvaluacion(int EvaluacionId, int EstudianteId);
        void responderEvaluacion(RespuestaEvaluacionRequest evaluacion);
        EvaluacionResponse obtenerEvaluacion(int EvaluacionId);
        bool FechaLimiteEvaluacion(int IdEvaluacion);
        List<EvaluacionCursoResponse> ObtenerEvaluacionesDelCurso(int CursoId);
        int ObtenerIdCalifacion(int idEvaluacion,int idEstudiante);
        void EditarCalifacion(int idEvaluacion, int idEstudiante, int Nota);

    }
}
