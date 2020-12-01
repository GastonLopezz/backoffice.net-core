using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos.Entity.GlobalesEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Negocio.Dto;
using Negocio.Services.Interfaces;
using Negocio.Services.Password;
using Presentacion.Models;

namespace Presentacion.Controllers {
    public class AdministradorController : Controller {
        private readonly IUserService userService;
        private readonly IFacultadesService facultadService;
        private readonly IMultyTenancyService multyTenancyService;

        /*    public FacultadController(IFacultadesService ifs) {
                facultadesService = ifs;
            }*/

        public AdministradorController(IMultyTenancyService mt, IUserService ias, IFacultadesService ifs) {
            userService = ias;
            facultadService = ifs;
            multyTenancyService = mt;
        }

        // GET: FacultadController
        public ActionResult Index() {
            var cookieValue = Request.Cookies["UrlFacultad"];
            multyTenancyService.SeleccionarNodoFacultad(cookieValue);
            var lista = userService.ListarAdministrador();
            var user = new AdministradorViewModel(lista);
            return View(user);
        }

        public IActionResult Add() {
            var lista = facultadService.ListarFacultades();
            var facu = new AdministradorViewModel(lista);
            return View(facu);
        }

        [HttpPost]
        public IActionResult Add(AdministradorViewModel model) {
            if (ModelState.IsValid) {
                var cookieValue = Request.Cookies["UrlFacultad"];
                multyTenancyService.SeleccionarNodoFacultad(cookieValue);
                string salt = PassSalt.Create();
                string hash = PassHash.Create(model.Password, salt);
                var a = new Administrador() {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Usuario = model.Usuario,
                    Passwd = hash,
                    Salt = salt,
                };
                userService.AddAdministrador(a, model.Tipo_Administrador, model.Facultad);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id) {
            var admin = userService.get(id);
            var adminModel = new AdministradorViewModel() {
                Id = id,
                Nombre = admin.Nombre,
                Apellido = admin.Apellido,
            };
            return View(adminModel);
        }

        [HttpPost]
        public IActionResult Edit(AdministradorViewModel model) {
            var cookieValue = Request.Cookies["UrlFacultad"];
            multyTenancyService.SeleccionarNodoFacultad(cookieValue);
            var admin = new Administrador() {
                Id = model.Id,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
            };
            userService.ModifyAdministrador(admin);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            userService.DeleteAdministrador(id);
            return RedirectToAction("Index");
        }
    }
}


