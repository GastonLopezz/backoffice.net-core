using Datos.Entity;
using Negocio.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces {
    public interface IDocenteService {
        void ConfigurarClaveMatriculacion(int IdCurso, string Clave, string Opcion);
        Curso getClave(int IdCurso);
        IEnumerable<PersonaCuentaResponse> GetEstudiantesDelCurso(int IdCurso);
        IEnumerable<PersonaCuentaResponse> GetDocentesDelCurso(int IdCurso);
        bool DocenteEncargado(int IdCuenta, int IdCurso);
        bool AsignarDocente(int IdCurso,int usuarioEncargado, int nuevoDocente);
        void BorrarDocenteAsignado(int IdCurso, int idNuevoDocente);
        Cuenta get(int id);
        void AddDocente(Cuenta d);
        void DeleteDocente(int IdCuenta);
        void ModifyDocente(Cuenta model);
        bool ValidateDocente(string usuario);
        List<Cuenta> ListarDocente();
        string IngresarNotaFinal(int idCurso, int ci, int notaFinal);
		List<Persona> ListarDocente2();
        bool AsignarDocenteCurso(int idCurso, int idDocente);
        List<Curso> ListarCursosDocente(int idCuentaDocente);
        void DeleteDocenteAsignacion(int idCurso, int IdCuenta);

        string ObtenerNotaCurso(int ci, int cursoId, int FacultadId);

        public List<string> ObtenerNotasEstudiante(int ci, int FacultadId);
    }
}
