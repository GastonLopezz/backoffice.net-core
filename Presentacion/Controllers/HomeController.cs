using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Datos.Entity.GlobalesEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocio.Services.Interfaces;
using Presentacion.Models;

namespace Presentacion.Controllers {
    public class HomeController : Controller {
        // GET: HomeController
        private readonly ILogger<HomeController> _logger;
        private readonly IMultyTenancyService multyTenancy;
        private readonly IUserService userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ILogger<HomeController> logger, IMultyTenancyService ms, IUserService ius, IHttpContextAccessor httpContextAccessor) {
            _logger = logger;
            userService = ius;
            multyTenancy = ms;
            _httpContextAccessor = httpContextAccessor;
        }
     
        CookieOptions option = new CookieOptions() {
           // Expires = DateTime.Now.AddMinutes(1)
        };
       
        public ActionResult Index() {
            return View();
        }

        public ActionResult Logout() {
            return RedirectToAction("Index");
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        public ActionResult MenuAdminFacu() {
            return View();
        }

        public ActionResult MenuAdminUdelar() {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(AdministradorViewModel model) {
            var u = userService.VerificarLoginAdministradores(model.Usuario, model.Password);
            if (u == null) {
                var mensaje = new AdministradorViewModel("Error de usuario y/o contraseña");
                return View("Index", mensaje);
            } else if(u.TipoCuenta == "Udelar") {
                Response.Cookies.Append("IdAdministrador", u.Id.ToString(), option);
                return RedirectToAction(nameof(MenuAdminUdelar));
            } else {
               var urlFac= multyTenancy.SelecionarTenanAdminFacu(u.Id);
                Response.Cookies.Append("UrlFacultad", urlFac, option);
                Response.Cookies.Append("IdAdministrador",u.Id.ToString(), option);
    
                return RedirectToAction(nameof(MenuAdminFacu));
            }
        }

  
    }
}
