#pragma checksum "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50e3870f7736a4955a680c4d12027ddd8f42eb98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Presentacion.Pages.Persona.Views_Persona_Edit), @"mvc.1.0.view", @"/Views/Persona/Edit.cshtml")]
namespace Presentacion.Pages.Persona
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50e3870f7736a4955a680c4d12027ddd8f42eb98", @"/Views/Persona/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"182c3e91b32ea8a235c851f1e3419ceac5b361a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Persona_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Presentacion.Models.PersonaViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div style=\"padding:20px;\"></div>\r\n");
#nullable restore
#line 3 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Edit.cshtml"
 using (Html.BeginForm()) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <fieldset>\r\n        <legend>Editar Perfil del Usuario</legend>\r\n        <div style=\"padding:5px;\"></div>\r\n        <div class=\"editor-label\">\r\n            ");
#nullable restore
#line 8 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Edit.cshtml"
       Write(Html.LabelFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
#nullable restore
#line 11 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Edit.cshtml"
       Write(Html.EditorFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 12 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Edit.cshtml"
       Write(Html.ValidationMessageFor(model => model.Nombre, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div style=\"padding:5px;\"></div>\r\n        <div class=\"editor-label\">\r\n            ");
#nullable restore
#line 16 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Edit.cshtml"
       Write(Html.LabelFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
#nullable restore
#line 19 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Edit.cshtml"
       Write(Html.EditorFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 20 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Edit.cshtml"
       Write(Html.ValidationMessageFor(model => model.Apellido, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        ");
#nullable restore
#line 22 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Edit.cshtml"
   Write(Html.HiddenFor(model => model.Ci));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"buttons\">\r\n            <br />\r\n            <input type=\"submit\" value=\"Editar\" />\r\n        </div>\r\n    </fieldset>\r\n");
#nullable restore
#line 28 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Edit.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Presentacion.Models.PersonaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
