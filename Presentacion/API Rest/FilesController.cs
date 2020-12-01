using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto;
using Negocio.Services.Interfaces;

namespace Presentacion.API_Rest {
    [Route("api/files")]
    [ApiController]
    //[Authorize]
    public class FilesController : ControllerBase {
        private IMultyTenancyService _nodoFacultad;
        private IMaterialService _materialService;

        public FilesController(IMaterialService ms, IMultyTenancyService nodo) {
            _materialService = ms;
            _nodoFacultad = nodo;
        }

        [HttpPost("archivo")]
        public ActionResult SubirArchivo([FromForm] FileModel file) {
            try {
                _nodoFacultad.SeleccionarNodoFacultad(file.Facultad);//Establecemos el nodo al cual ir

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);
                Console.WriteLine(path);
                using (Stream stream = new FileStream(path, FileMode.Create)) {
                    file.FormFile.CopyTo(stream);
                }
                _materialService.SubirArchivo(file.SeccionId,file.FileName,path);
                return StatusCode(StatusCodes.Status201Created);
            } catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("ArchivoEvaluacion")]
        public IActionResult SubirArchivoEvaluacion([FromBody] ArchivoEvaluacionModel file){
            try
            {
                //Establecemos el nodo al cual ir
                _nodoFacultad.SeleccionarNodoFacultad(file.Facultad);
                string res = _materialService.SubirArchivoEvaluacion(file.EvaluacionId, file.CuentaId, file.ArchivoBase64, file.NombreArchivo);

                if (string.IsNullOrEmpty(res))
                {
                    return Ok("Se ha subido el archivo.");
                }
                return BadRequest(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("DescargarArchivo")]
        public FileResult DescargarArchivo(string nombre, string facultad)
        {
            _nodoFacultad.SeleccionarNodoFacultad(facultad);
            var res = _materialService.DescargarArchivo(nombre);
            return File(res.Archivo, System.Net.Mime.MediaTypeNames.Application.Octet, res.Nombre);
        }

        [HttpGet("ArchivosEvaluaciones")]
        public IActionResult ListaArchivos(string facultad)
        {
            _nodoFacultad.SeleccionarNodoFacultad(facultad);
            return Ok(_materialService.ListaArchivosEvaluaciones());
        }

        [HttpGet("download")]
        public async Task<IActionResult> Download(string filename) {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open)) {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private string GetContentType(string path) {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes() {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".rar", "application/x-rar-compressed, application/octet-stream"},
                {".zip", "application/zip, application/octet-stream, multipart/x-zip" }
            };
        }
        [HttpPost("texto")]
        public ActionResult SubirTexto(TextoRequest model) {
            _nodoFacultad.SeleccionarNodoFacultad(model.Facultad);//Establecemos el nodo al cual ir
            _materialService.SubirTexto(model.SeccionId, model.Texto,model.Titulo);
            return Ok();
        }

    }
}
