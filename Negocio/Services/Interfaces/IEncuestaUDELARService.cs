using Negocio.Dto.Encuestas;
using Negocio.Dto.Encuestas.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces
{
    public interface IEncuestaUDELARService
    {
        void AddEncuesta(EncuestaGeneralRequest encuesta);
        EncuestaGeneralResponse ObtenerEncuestaParaResponder(int encuestaId);
        List<EncuestaGeneralResponse> ObtenerEncuestas();
        //List<PreguntasEstadisticaResponse> Estadisticas(int cursoId, int idEncuesta);
        void BorrarEncuesta(int idEncuesta);
        void ResponderEncuesta(ResponderEncuestaGeneralRequest respuestas);
    }
}
