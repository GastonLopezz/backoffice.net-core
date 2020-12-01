using Datos.Entity;
using Datos.Entity.GlobalesEntity;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto;
using Negocio.Services.Interfaces;
using Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers {
    public class DocenteController : Controller {

            private readonly IDocenteService docenteService;
            private readonly IUserService userService;
            private readonly ICursoService cursoService;
            private readonly IMultyTenancyService multyTenancyService;

            public DocenteController(IMultyTenancyService mt, IDocenteService ids, IUserService ius, ICursoService ics) {
                docenteService = ids;
                userService = ius;
                cursoService = ics;
                multyTenancyService = mt;
            }

            public IActionResult Index() {
                var cookieValue = Request.Cookies["UrlFacultad"];
                multyTenancyService.SeleccionarNodoFacultad(cookieValue);
                var lista = docenteService.ListarDocente2();
                var user = new DocenteViewModel(lista);
                 return View(user);
            }

            public IActionResult Add() {
                return View();
            }

            [HttpPost]
            public IActionResult Add(DocenteViewModel model) {
                if (ModelState.IsValid) {
                var cookieValue = Request.Cookies["UrlFacultad"];
                multyTenancyService.SeleccionarNodoFacultad(cookieValue);
                if (!docenteService.ValidateDocente(model.Usuario)) {
                        CreateUserRequest cu = new CreateUserRequest() {
                            Usuario = model.Usuario,
                            Cedula = model.Ci,
                            Email = model.Email,
                            Password = model.Password,
                            Telefono = model.Telefono,
                            TipoCuenta = "Docente",
                            Nombre = model.Nombre,
                            Apellido = model.Apellido,
                        };
                        userService.CrearCuenta(cu);
                        return RedirectToAction("Index");
                    }
                }
                return View(model);
            }

            public IActionResult Edit(int id) {
                var docente = userService.getDocente(id);
                var personaModel = new PersonaViewModel() { 
                    Id = id,
                    Nombre = docente.Nombre,
                    Apellido = docente.Apellido,
                };
                return View(personaModel);
            }

            [HttpPost]
            public IActionResult Edit(DocenteViewModel model) {
            var cookieValue = Request.Cookies["UrlFacultad"];
            multyTenancyService.SeleccionarNodoFacultad(cookieValue);
            var docente = userService.getDocente(model.Id);
                docente.Nombre = model.Nombre;
                docente.Apellido = model.Apellido;
                userService.ModifyDocente(docente);
                return RedirectToAction("Index");
             }

            public IActionResult Delete(int id) {
                docenteService.DeleteDocente(id);
                return RedirectToAction("Index");
            }

            public IActionResult DeleteAsignacionDocente(int cursoId,int docenteId) {
                docenteService.DeleteDocenteAsignacion(cursoId, docenteId);
                return RedirectToAction("Index");
            }

            public IActionResult AsignarCurso(int id,int ci, string nombre , string apellido) {
                    var d = docenteService.ListarCursosDocente(id);   
                    var lista = cursoService.ListarCurso();
                    var c = new DocenteViewModel(lista, id, ci, nombre, apellido, d);
                    return View(c);
                }

            [HttpPost]
            public IActionResult AsignarCurso(DocenteViewModel model) {
                docenteService.AsignarDocenteCurso(model.Cursos, model.Id);             
                return RedirectToAction("AsignarCurso");
            }
    }
}



