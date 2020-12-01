using Datos.Entity;
using Negocio.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces
{
    public interface IClaseService
    {
        void AgregarAsistencia(int idClase, int idUsuario);
        string NuevaClase(int cursoId, DateTime fecha, DateTime start, DateTime end);
        string EliminarClase(int idClase);
        string ModificarClase(int idClase, DateTime fecha, DateTime start, DateTime end);
        List<AsistenciaResponse> ListarAsistencias(int IdCurso,DateTime Fecha);
        List<AsistenciaResponse> ListarAsistenciaUsuario(int idUsuario,int IdCurso);
        List<Clase> ListarClases(int IdCurso);
        void BorrarClase(int IdClase);
        int GetClaseToday(int IdCurso,int usuarioId);

    }
}
