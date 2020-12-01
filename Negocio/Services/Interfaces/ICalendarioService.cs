using Datos.Entity;
using System;
using System.Collections.Generic;

namespace Negocio.Services.Interfaces
{
    public interface ICalendarioService
    {
        string NuevoEvento(int cursoId, string titulo, string facultad, DateTime fecha);
        List<DateTime> ObtenerEventos(int cursoId);
        string BorrarEvento(int cursoId, DateTime fecha);

        string ObtenerEvento(int cursoId, DateTime fecha);
    }
}
