using Datos.Context;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Services
{
    public class ComentarioService : IComentarioService
    {
        private ContextoParticular _context;
        public ComentarioService(ContextoParticular ctx)
        {
            _context = ctx;
        }

        /*public string AgregarComentario()
        {

        }*/
    }
}
