using Datos.Entity;
using Negocio.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services.Interfaces {
   public interface IMaterialService {
        void SubirArchivo(int SeccionId,string titulo,string path);
        void SubirTexto(int SeccionId, string texto, string titulo);
        string SubirArchivoEvaluacion(int evaluacionId, int cuentaId, string archivoBase64, string nombre);
        List<ArchivoEvaluacionResponse> ListaArchivosEvaluaciones();
        ArchivoEvaluacion DescargarArchivo(string nombre);

    }
}
