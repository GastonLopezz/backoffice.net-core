#pragma checksum "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Home\MenuAdminUdelar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7618aa11cb61abf49e35db0ad541bc8b574d67ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Presentacion.Pages.Home.Views_Home_MenuAdminUdelar), @"mvc.1.0.view", @"/Views/Home/MenuAdminUdelar.cshtml")]
namespace Presentacion.Pages.Home
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\_ViewImports.cshtml"
using Presentacion;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7618aa11cb61abf49e35db0ad541bc8b574d67ea", @"/Views/Home/MenuAdminUdelar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"182c3e91b32ea8a235c851f1e3419ceac5b361a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_MenuAdminUdelar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n    <br />\r\n    <br />\r\n    <h5>Menú de Opciones</h5>\r\n    <br />\r\n    <center>\r\n        ");
#nullable restore
#line 7 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Home\MenuAdminUdelar.cshtml"
   Write(Html.ActionLink("Administrador", "Index", "administrador"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        |\r\n        ");
#nullable restore
#line 9 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Home\MenuAdminUdelar.cshtml"
   Write(Html.ActionLink("Facultades", "Index", "facultad"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        |\r\n        ");
#nullable restore
#line 11 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Home\MenuAdminUdelar.cshtml"
   Write(Html.ActionLink("Logout", "Index", "home", new { onclick = "return confirm('Está seguro que desea salir?')" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </center>\r\n            <br />\r\n            <br />\r\n\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591