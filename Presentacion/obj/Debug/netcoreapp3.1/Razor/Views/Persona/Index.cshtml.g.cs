#pragma checksum "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9dbe4bfc351d41c97745e59768841dd3de24bbf0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Presentacion.Pages.Persona.Views_Persona_Index), @"mvc.1.0.view", @"/Views/Persona/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9dbe4bfc351d41c97745e59768841dd3de24bbf0", @"/Views/Persona/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"182c3e91b32ea8a235c851f1e3419ceac5b361a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Persona_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Presentacion.Models.PersonaViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div style=\"padding:20px;\"></div>\r\n");
#nullable restore
#line 3 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
 using (Html.BeginForm()) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <fieldset>\r\n        <legend>Usuarios</legend>\r\n        <br />\r\n        ");
#nullable restore
#line 7 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
   Write(Html.ActionLink("Crear un nuevo usuario", "Add", "Persona"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <br />\r\n        <br />\r\n        <table class=\"table table-bordered\">\r\n            <thead>\r\n                <tr>\r\n                    <th scope=\"col\">\r\n                        ");
#nullable restore
#line 14 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Ci));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th scope=\"col\">\r\n                        ");
#nullable restore
#line 18 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th scope=\"col\">\r\n                        ");
#nullable restore
#line 22 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th scope=\"col\">\r\n                        Opciones\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 30 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
                 foreach (var item in Model.LstPersona) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 33 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
                       Write(Html.DisplayFor(item1 => item.Ci));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 36 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
                       Write(Html.DisplayFor(item1 => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 39 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
                       Write(Html.DisplayFor(item1 => item.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 42 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
                       Write(Html.ActionLink("Editar", "edit", "Persona", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 43 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
                       Write(Html.ActionLink("Eliminar", "delete", "Persona", new { id = item.Id }, new { onclick = "return confirm('Are you sure you want to delete?')" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 46 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </fieldset>\r\n");
#nullable restore
#line 50 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Persona\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
