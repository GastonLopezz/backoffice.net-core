using Negocio.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Negocio.Services.Interfaces {
    public interface IMultyTenancyService {
        void SeleccionarNodoFacultad(string Url);
        List<string> ObtenerNodos();
        List<string> ObtenerNodosUrl();
		string ObtenerUrlFacultad(string url);
        string SelecionarTenanAdminFacu(int idAdmin);
        string ObtenerNombreFacultad(string nombreBD);
        int ObtenerIdFacultad(string url);
    }
}
