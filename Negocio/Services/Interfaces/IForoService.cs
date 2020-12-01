using Datos.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces
{
    public interface IForoService
    {
        string NuevoForo(string nombre, int seccionId, bool suscripcion);
        string EliminarForo(int idForo);
        string ModificarForo(int id, int seccionId, bool suscripcion, string nombre);
        List<Foro> ObtenerForos(int idCurso);
        string PublicarDiscusion(int idForo, int idCuenta, string titulo);
        Foro GetForo(int idForo);
        string SuscribirseAForo(int idForo, int idUsuario);
        List<Suscripcion> ListarSuscripciones();
    }
}
