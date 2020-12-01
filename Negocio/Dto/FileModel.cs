using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Dto {
    public class FileModel {
        public string FileName { get; set; }
        public int SeccionId { get; set; }
        public string Facultad { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
