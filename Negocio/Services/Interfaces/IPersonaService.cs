using Datos.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces {
    public interface IPersonaService {
        Persona get(int id);
        void AddPersona(Persona p);
        void DeletePersona(int IdPersona);
        void ModifyPersona(Persona model);
        bool ValidatePersona(int usuario);
        List<Persona> ListarPersona();
    }
}
