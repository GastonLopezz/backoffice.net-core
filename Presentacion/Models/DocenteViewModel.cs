using Datos.Entity;
using System.Collections.Generic;

namespace Presentacion.Models {
    public class DocenteViewModel {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public int Ci { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Tipo_Cuenta { get; set; }
        public int PersonaId { get; set; }
        public int Cursos { get; set; }
        public List<Curso> LstCursosDisctados = new List<Curso>();

        public DocenteViewModel() { }
        public List<Persona> LstCuenta = new List<Persona>();
        public DocenteViewModel(List<Persona> docente) {
            foreach (var d in docente) {
                LstCuenta.Add(d);
            }
        }

        public List<Curso> LstCursos = new List<Curso>();
        public DocenteViewModel(List<Curso> curso, int id, int ci, string nombre, string apellido, List<Curso> cursoAsignados) {
            foreach (var d in curso) {
                LstCursos.Add(d);
            }
            Id = id;
            Ci = ci;
            Nombre = nombre;
            Apellido = apellido;
            foreach (var i in cursoAsignados) {
                LstCursosDisctados.Add(i);
            }
        }
    }
}