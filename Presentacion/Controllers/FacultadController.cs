using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos.Entity.GlobalesEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Negocio.Dto;
using Negocio.Dto.Response;
using Negocio.Services.Interfaces;
using Presentacion.Models;

namespace Presentacion.Controllers {
    public class FacultadController : Controller {
        private readonly IFacultadesService facultadesService;
        private readonly IMultyTenancyService multyTenancyService;
        CookieOptions option = new CookieOptions() {};
        public FacultadController(IMultyTenancyService mt, IFacultadesService ifs) {
            facultadesService = ifs;
            multyTenancyService = mt;
        }

        // GET: FacultadController
        public ActionResult Index() {
            var cookieValue = Request.Cookies["UrlFacultad"];
            multyTenancyService.SeleccionarNodoFacultad(cookieValue);
            var lista = facultadesService.ListarFacultades();
           var f = new FacultadViewModel(lista);
           return View(f);
        }

        public ActionResult ListarComunicados(string url) {
            var lista = facultadesService.ComunicadoFacultades(url);
            var f = new FacultadViewModel(lista);
            return View(f);
        }

        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public IActionResult Add(FacultadViewModel model) {
            if (ModelState.IsValid) {
                var cookieValue = Request.Cookies["UrlFacultad"];
                multyTenancyService.SeleccionarNodoFacultad(cookieValue);
                if (!facultadesService.ValidateFacultad(model.Abreviatura, model.Url)) {
                    var f = new Facultad() {
                        Nombre = model.Nombre,
                        Abreviatura = model.Abreviatura,
                        Url = model.Url,
                        Logo = model.Logo,
                        ColorNav = model.Color,
                        TipoNav = model.Tipo,
                        TipoAutenticacion = model.Tipo_Autenticacion,
                        NombreBD = model.Abreviatura,
                    };
                    facultadesService.AddFacultad(f);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public IActionResult Edit(int id) {
            var facu = facultadesService.get(id);
            var facuModel = new FacultadViewModel() {
                Id = id,
                Nombre = facu.Nombre,
                Abreviatura = facu.Abreviatura,
                Url = facu.Url,
                Logo = facu.Logo,
                Color = facu.ColorNav,
                Tipo = facu.TipoNav,
                Tipo_Autenticacion = facu.TipoAutenticacion
        };
            return View(facuModel);
        }

        [HttpPost]
        public IActionResult Edit(FacultadViewModel model) {
            var cookieValue = Request.Cookies["UrlFacultad"];
            multyTenancyService.SeleccionarNodoFacultad(cookieValue);
            var facu = facultadesService.get(model.Id);
            facu.Nombre = model.Nombre;
            facu.Abreviatura = model.Abreviatura;
            facu.Url = model.Url;
            facu.Logo = null;
            facu.TipoAutenticacion = model.Tipo_Autenticacion;
            facultadesService.ModifyFacultad(facu);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            facultadesService.DeleteFacultad(id);
            return RedirectToAction("Index");
        }

        public IActionResult ComunicadoFacultad(string url) {
            Response.Cookies.Append("UrlProvisorio", url, option);
            return View();
        }

        [HttpPost]
        public IActionResult ComunicadoFacultad(ComunicadosViewModel model) {
            var cookieValue = Request.Cookies["UrlProvisorio"];
            var idAdmin = Int16.Parse(Request.Cookies["IdAdministrador"]);
            var m = multyTenancyService.ObtenerIdFacultad(cookieValue);
            var c = new Comunicado() {
                Id = model.Id,
                Titulo = model.Titulo,
                Texto = model.Texto,
                FechaPublicacion = model.Fecha_Publicacion

            };
            facultadesService.PublicarComunicadoFacultad(m, c.Titulo, c.Texto, idAdmin);
            return RedirectToAction("Index");
            //return View(model);
        }
    }
}


