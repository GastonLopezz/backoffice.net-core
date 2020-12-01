using Datos.Context;
using Datos.Entity;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Services {
    public class PersonaService : IPersonaService {
        private readonly ContextoParticular _context;
        public PersonaService(ContextoParticular ctx) {
            _context = ctx;
        }

        public Persona getClave(int IdPersona) {
            return _context.Persona.SingleOrDefault(t => t.Id == IdPersona);
        }

        public void AddPersona(Persona p) {
            _context.Persona.Add(p);
            _context.SaveChanges();
        }

        public void DeletePersona(int IdPersona) {
            var p = _context.Persona.SingleOrDefault(t => t.Id == IdPersona);
            _context.Persona.Remove(p);
            _context.SaveChanges();
            //Borar base de datos cuando se borra la facultad
        }

        public void ModifyPersona(Persona model) {
            var f = _context.Persona.SingleOrDefault(t => t.Id == model.Id);
            f.Nombre = model.Nombre;
            f.Apellido = model.Apellido;
            _context.SaveChanges();
        }


        public bool ValidatePersona(int Ci) {
            return _context.Persona.Any(t => t.Ci == Ci);
        }

        public List<Persona> ListarPersona() {
            return _context.Persona.ToList();
        }

        public Persona get(int id) {
            var f = _context.Persona.SingleOrDefault(t => t.Id == id);
            return f;
        }
    }
}
