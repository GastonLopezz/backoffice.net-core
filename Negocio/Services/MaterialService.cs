using Datos.Context;
using Datos.Entity;
using Datos.Entity.EvaluacionEntity;
using Negocio.Dto.Response;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Negocio.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly ContextoParticular _context;
        public MaterialService(ContextoParticular ctx){
            _context = ctx;
        }

        public void SubirArchivo(int SeccionId, string titulo, string path)
        {
            var material = new Material()
            {
                Nombre = titulo,
                Url = path,
                SeccionId = SeccionId
            };
            _context.Material.Add(material);
            _context.SaveChanges();
        }
        public void SubirTexto(int SeccionId, string texto, string titulo)
        {
            var info = new Informacion()
            {
                Titulo = titulo,
                Descripcion = texto,
                Fecha = DateTime.Now,
                SeccionTemplateId = SeccionId
            };
            _context.Informacion.Add(info);
            _context.SaveChanges();
        }

        public string SubirArchivoEvaluacion(int evaluacionId, int cuentaId, string archivoBase64, string nombre)
        {

            string ret = "";
            try
            {//Fecha de Entrega pasada
                byte[] archivo = Base64AArchivo(archivoBase64);
                MemoryStream stream = new MemoryStream();
                stream.Write(archivo, 0, archivo.Length);
                var data = _context.ArchivoEvaluaciones.SingleOrDefault(x => x.EvaluacionId == evaluacionId && x.CuentaId == cuentaId);
                if (data == null) {//No hay Data
                    ArchivoEvaluacion archivoEvaluacion = new ArchivoEvaluacion() {
                        EvaluacionId = evaluacionId,
                        Nombre = nombre,
                        Archivo = stream.ToArray(),
                        Creado = DateTime.Now,
                        CuentaId = cuentaId //usuarioId
                    };
                    _context.ArchivoEvaluaciones.Add(archivoEvaluacion);
                    generarCalificacion(evaluacionId,cuentaId);
                } else {//Update Data
                    data.Nombre = nombre;
                    data.Archivo = stream.ToArray();
                    data.Creado = DateTime.Now;
                }
                _context.SaveChanges();
                return ret;
            }
            catch (Exception ex)
            {
                return ret = ex.Message;
            }
            
        }

        private static byte[] Base64AArchivo(string archivoBase64)
        {
            byte[] archivoBytes = Convert.FromBase64String(archivoBase64);
            MemoryStream ms = new MemoryStream(archivoBytes, 0, archivoBytes.Length);
            
            
            ms.Write(archivoBytes, 0, archivoBytes.Length);
            //return File.ReadAllBytes(archivoBase64);
            return archivoBytes;
        }

        public ArchivoEvaluacion ObtenerArchivoEvaluacion(int evaluacionId, int cuentaId)
        {
            List<ArchivoEvaluacion> archivos = _context.ArchivoEvaluaciones.ToList();
            foreach (var item in archivos)
            {
                if((item.EvaluacionId == evaluacionId) && (item.CuentaId == cuentaId))
                {
                    return item;
                }
            }
            return null;
        }

        public List<ArchivoEvaluacionResponse> ListaArchivosEvaluaciones()
        {
            List<ArchivoEvaluacionResponse> lista = new List<ArchivoEvaluacionResponse>();
            foreach(var archivo in _context.ArchivoEvaluaciones.ToList())
            {
                var respuesta = new ArchivoEvaluacionResponse
                {
                    Creado = archivo.Creado,
                    CuentaId = archivo.CuentaId,
                    EvaluacionId = archivo.EvaluacionId,
                    Id = archivo.Id,
                    Nombre = archivo.Nombre,
                    Tipo = archivo.Tipo
                };
                lista.Add(respuesta);
            }
            return lista;
        }

        public ArchivoEvaluacion DescargarArchivo(string nombre)
        {
            string filename = Path.GetFileName(nombre);
            var archivo = _context.ArchivoEvaluaciones.SingleOrDefault(a => a.Nombre == nombre);
            if(archivo != null)
            {
                return archivo;
               /* MemoryStream ms = new MemoryStream();
                ms.Read(archivo.Archivo, 0, archivo.Archivo.Length);
                byte[] bytes = ms.ToArray();
                using (var fs = new FileStream(archivo.Nombre, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    //return fs;
                }*/

               

            }
            return null;
            
        }

        private void generarCalificacion(int EvaluacionId, int EstudianteId) {
            var evaluacion = _context.Evaluaciones.SingleOrDefault(e => e.Id == EvaluacionId);
            if (evaluacion == null) {
                throw (new Exception("La calificacion no existe o no esta publicada"));
            }
            if (!existeCalificacion(evaluacion.Id, EstudianteId)) {
                var calificacion = new Calificacion {
                    EstadoCalificacion = "Pendiente",
                    FechaPublicada = DateTime.Now,
                    EstudianteId = EstudianteId,
                    Evaluacion = evaluacion,
                    EvaluacionId = evaluacion.Id
                };
                _context.Calificaciones.Add(calificacion);
                _context.SaveChanges();

            }
        }

        private bool existeCalificacion(int EvaluacionId, int EstudianteId) {
            var calificacion = _context.Calificaciones.SingleOrDefault(e => e.EvaluacionId == EvaluacionId && e.EstudianteId == EstudianteId);
            if (calificacion == null) {
                return false;
            }
            return true;
        }

    }
}
