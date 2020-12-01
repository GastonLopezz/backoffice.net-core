using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Datos.Entity;
using Datos.Entity.GlobalesEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto;
using Negocio.Dto.Response;
using Negocio.Services.Interfaces;
using Presentacion.Models;

namespace Presentacion.Controllers {
    public class CursoController : Controller {
        private readonly ICursoService cursoService;
        private readonly IMultyTenancyService multyTenancyService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMultyTenancyService multyTenancy;
        CookieOptions option = new CookieOptions() { };
        public CursoController(IMultyTenancyService mt, ICursoService ics, IHttpContextAccessor httpContextAccessor) {
            cursoService = ics;
            multyTenancyService = mt;
            _httpContextAccessor = httpContextAccessor;
        }
       
        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CursoViewModel model) {
            if (ModelState.IsValid) {
                var cookieValue = Request.Cookies["UrlFacultad"];
                multyTenancyService.SeleccionarNodoFacultad(cookieValue);
                if (!cursoService.ValidateCurso(model.Nombre)) {
                    var c = new Curso() {
                        Nombre = model.Nombre,
                        Creditos = model.Creditos,
                        ClaveMatriculacion = model.Clave_Matriculacion,
                        YearDiactado = model.Year_Diactado,
                        TipoCurso = model.Tipo_Curso,
                        DictaCurso = model.Dicta_Curso,
                        Informacion = model.Informacion,
                        NotaMinimaAprobacion = model.Nota_Minima_Aprobacion,
                        NotaMaximaAprobacion = model.Nota_Maxima_Aprobacion,
                        NotaMinimaExamen = model.Nota_Minima_Examen,
                        NotaMaximaExamen = model.Nota_Maxima_Examen
                    };
                    cursoService.AddCurso(c);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public IActionResult Edit(int id) {
            var curso = cursoService.get(id);
            var cursoModel = new CursoViewModel() {
                Id = id,
                Nombre = curso.Nombre,
                Creditos = curso.Creditos,
                Year_Diactado = curso.YearDiactado,
                Tipo_Curso = null,
                Dicta_Curso = null,
                Informacion = curso.Informacion,
                Nota_Minima_Aprobacion = curso.NotaMinimaAprobacion,
                Nota_Maxima_Aprobacion = curso.NotaMaximaAprobacion,
                Nota_Minima_Examen = curso.NotaMinimaExamen,
                Nota_Maxima_Examen = curso.NotaMaximaExamen
            };
            return View(cursoModel);
        }

        [HttpPost]
        public IActionResult Edit(CursoViewModel model) {
            var cookieValue = Request.Cookies["UrlFacultad"];
            multyTenancyService.SeleccionarNodoFacultad(cookieValue);
            var curso = cursoService.get(model.Id);
            curso.Nombre = model.Nombre;
            curso.Creditos = model.Creditos;
            curso.YearDiactado = model.Year_Diactado;
            curso.TipoCurso = null;
            curso.DictaCurso = null;
            curso.Informacion = model.Informacion;
            curso.NotaMinimaAprobacion = model.Nota_Minima_Aprobacion;
            curso.NotaMaximaAprobacion = model.Nota_Maxima_Aprobacion;
            curso.NotaMinimaExamen = model.Nota_Minima_Examen;
            curso.NotaMaximaExamen = model.Nota_Maxima_Examen;
            cursoService.ModifyCurso(curso);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            cursoService.DeleteCurso(id);
            return RedirectToAction("Index");
        }

        public IActionResult Index() {//El tenana ya se seleciono en el login
            var cookieValue = Request.Cookies["UrlFacultad"];
             multyTenancyService.SeleccionarNodoFacultad(cookieValue);
            var lstCurso=cursoService.ObtenerCursos();
            List<Curso> lst = new List<Curso>();
            foreach( var c in lstCurso) {
                var cvm = new Curso() {
                    Id = c.Id,
                    Nombre=c.Nombre,
                    Creditos = c.Creditos,
                };
                lst.Add(cvm);
            }
            var cursoVM = new CursoViewModel(lst);
            return View("Index", cursoVM);
        }

      public IActionResult ComunicadoCurso(int id) {
            Response.Cookies.Append("IdCurso", id.ToString(), option);
            return View();
        }

        [HttpPost]
        public IActionResult ComunicadoCurso(ComunicadosViewModel model) {
            multyTenancyService.SeleccionarNodoFacultad(Request.Cookies["UrlFacultad"]);
            var idCurso = Int16.Parse(Request.Cookies["IdCurso"]);
            var c = new Comunicado() {
                Id = model.Id,
                Titulo = model.Titulo,
                Texto = model.Texto,
                FechaPublicacion = model.Fecha_Publicacion,
            };
            cursoService.PublicarComunicadoCurso(idCurso, c.Titulo, c.Texto);
            return RedirectToAction("Index");
        }

        public ActionResult ListarComunicados(int idCurso) {
            multyTenancyService.SeleccionarNodoFacultad(Request.Cookies["UrlFacultad"]);
            var lista = cursoService.ListarComunicadoCurso(idCurso);
            var f = new CursoViewModel(lista);
            return View(f);
        }
    }
}



