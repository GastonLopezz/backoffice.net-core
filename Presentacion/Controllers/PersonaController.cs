using Datos.Entity;
using Microsoft.AspNetCore.Mvc;
using Negocio.Services.Interfaces;
using Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers {
    public class PersonaController : Controller {
        private readonly IPersonaService personaService;
        private readonly IMultyTenancyService multyTenancyService;

        public PersonaController(IMultyTenancyService mt, IPersonaService ips) {
            personaService = ips;
            multyTenancyService = mt;
        }

        public IActionResult Index() {
            var lista = personaService.ListarPersona();
            var user = new PersonaViewModel(lista);
            return View(user);
        }

        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonaViewModel model) {
            if (ModelState.IsValid) {
                if (!personaService.ValidatePersona(model.Ci)) {
                    var c = new Persona() {
                        Ci = model.Ci,
                        Nombre = model.Nombre,
                        Apellido = model.Apellido,
                        Cuentas = model.Persona
                    };
                    personaService.AddPersona(c);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public IActionResult Edit(int id) {
            var persona = personaService.get(id);
            var personaModel = new PersonaViewModel() {
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
            };
            return View(personaModel);
        }

        [HttpPost]
        public IActionResult Edit(PersonaViewModel model) {
            var persona = personaService.get(model.Id);
            persona.Nombre = model.Nombre;
            persona.Apellido = model.Apellido;
            personaService.ModifyPersona(persona);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            personaService.DeletePersona(id);
            return RedirectToAction("Index");
        }

    }
}
