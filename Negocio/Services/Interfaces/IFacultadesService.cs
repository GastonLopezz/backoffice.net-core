using Datos.Entity;
using Datos.Entity.GlobalesEntity;
using Negocio.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces {
    public interface IFacultadesService {

        void AddFacultad(Facultad f);
        void DeleteFacultad(int IdFacultad);
        void ModifyFacultad(Facultad model);
        bool ValidateFacultad(string abreviatura, string url);
        List<Facultad> ListarFacultades();
        void PublicarComunicadoFacultad(int IdFacultades, string titulo,string texto,int IdAdministrador);
        Facultad get(int id);
        //IEnumerable<CursoResponse> ObtenerCursos();
        List<ComunicadoResponse> ComunicadoFacultades(string urlFacultad);
        string TipoAutenticacion();
        List<CursoResponse> ObtenerCursos();
        void ActualizarAutenticacion(int idFacultad, string tipoAuth);
        void AddComunicadosFacultad(Comunicado c);
        FacultadDataResponse DatosFacultad(string url);
    }
}
