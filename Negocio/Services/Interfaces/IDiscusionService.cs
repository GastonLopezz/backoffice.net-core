using Datos.Entity;
using Negocio.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces
{
    public interface IDiscusionService
    {
        string NuevaDiscusion(int idCuenta, int idForo, string titulo);
        string EliminarDiscusion(int idForo, int idDiscusion);
        string AgregarComentario(int idForo, int idDiscusion, int idCuenta, string comentario);
        List<Discusion> ObtenerDiscusiones(int idForo);
        Discusion GetDiscusion(int idDiscusion);
        //List<ComentarioResponse> ObtenerComentariosDeDiscusion(int idForo, int idDiscusion)
        List<ComentarioResponse> ObtenerComentariosDeDiscusion(int idForo, int idDiscusion);
        List<Comentario> ObtenerComentarios(int idDiscusion);

    }
}
