using Datos.Entity;
using Datos.Entity.GlobalesEntity;
using Negocio.Dto;
using Negocio.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces
{
    public interface ICursoService{
        string MatricularmeACurso(int idCurso, string clave,int IdUsuario, int FacultadId);
        IEnumerable<CursoResponse> ObtenerCursos();
        bool ValidateCurso(string nombre);
        void AddCurso(Curso c);
        void DeleteCurso(int IdCurso);
        void ModifyCurso(Curso model);
        Curso get(int id);
        List<CursoResponse> MisCursos(int usuarioId);
        List<CursoResponse> MisCursosDocente(int usuarioId);
        List<SeccionTemplate> GetDataCurso(int idCurso);
        string GetNombreCurso(int Id);
        void BorrarSeccion(int SeccionId);
        void AgregarSeccion(int cursoId, string nombre);
        List<Curso> ListarCurso();
        void AddComunicadosCurso(ComunicadoCurso c);
        void PublicarComunicadoCurso(int IdCurso, string titulo, string texto);
        List<ComunicadoCurso> ListarComunicadoCurso(int CursoId);
    }
}
