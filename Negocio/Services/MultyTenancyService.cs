using Datos.Context;
using Microsoft.EntityFrameworkCore;
using Negocio.Dto;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Services {
    public class MultyTenancyService:IMultyTenancyService {
        private readonly ContextoGeneral _context_general;
        private readonly ContextoParticular _context_particular;

        public MultyTenancyService(ContextoGeneral ctx_general, ContextoParticular ctx_particular) {
            _context_general = ctx_general;
            _context_particular = ctx_particular;
        }

        public void SeleccionarNodoFacultad(string Url) {
            var facultad= _context_general.Facultad
                .SingleOrDefault(fac => fac.Url == Url);
               _context_particular.SchemaName = facultad.NombreBD;  
        }

        public List<string> ObtenerNodos() {
           return _context_general.Facultad
                .Select(x=> x.NombreBD)
                .ToList();
        }
		
		public List<string> ObtenerNodosUrl() {
            return _context_general.Facultad
                 .Select(x => x.Url)
                 .ToList();
        }
        public string ObtenerNombreFacultad(string nombreBD) {
            return _context_general.Facultad
                    .SingleOrDefault(x => x.NombreBD == nombreBD).Nombre;
        }
        public string ObtenerUrlFacultad(string url) {
            return _context_general.Facultad
                    .SingleOrDefault(x => x.Url == url).NombreBD;
        }

        public int ObtenerIdFacultad(string url) {
            return _context_general.Facultad
                    .SingleOrDefault(x => x.Url == url).Id;
        }

      
        public string SelecionarTenanAdminFacu(int idAdmin) {
            var facultadId = _context_general.AdministradorFacultad
              .SingleOrDefault(fac => fac.AdministradorId == idAdmin).FacultadId;
            var facultad=_context_general.Facultad.SingleOrDefault(f => f.Id == facultadId);
            _context_particular.SchemaName = facultad.NombreBD;
            return facultad.Url;

        }
    }
}
