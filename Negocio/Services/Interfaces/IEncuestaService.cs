using Negocio.Dto.Encuestas;
using Negocio.Dto.Encuestas.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces {
    public interface IEncuestaService {

        void AddEncuesta(EncuestaRequest encuesta);
        List<PreguntasEstadisticaResponse> EstadisticasCurso(int cursoId,int idEncuesta);
        List<EncuestaResponse> ObtenerEncuestasCurso(int cursoId);
        List<EncuestaResponse> ObtenerEncuestasFacultad(string facultadId);
        void BorrarEncuestaCurso(int idEncuesta);
        void BorrarEncuestaFacultad(int idEncuesta);
        EncuestaResponse ObtenerEncuestaParaResponder(int encuestaId);
        void ResponderEncuesta(ResponderEncuestaRequest respuestas);
        
        }
    }
