#pragma checksum "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a35472f2a09c8a5e253112ffbe4fc21013467ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Presentacion.Pages.Curso.Views_Curso_Index), @"mvc.1.0.view", @"/Views/Curso/Index.cshtml")]
namespace Presentacion.Pages.Curso
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a35472f2a09c8a5e253112ffbe4fc21013467ea", @"/Views/Curso/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"182c3e91b32ea8a235c851f1e3419ceac5b361a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Curso_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Presentacion.Models.CursoViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
Write(Html.ActionLink("Menú principal", "MenuAdminFacu", "home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    |\r\n");
#nullable restore
#line 4 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
Write(Html.ActionLink("Docentes", "Index", "docente"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    |\r\n");
#nullable restore
#line 6 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
Write(Html.ActionLink("Cursos", "Index", "curso"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"padding:20px;\"></div>\r\n<legend>Cursos</legend>\r\n<br />\r\n");
#nullable restore
#line 10 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
Write(Html.ActionLink("Crear un curso", "Add", "Curso"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<center>\r\n");
#nullable restore
#line 12 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
     using (Html.BeginForm()) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <fieldset>\r\n            <br />\r\n            <br />\r\n            <table class=\"table table-bordered\">\r\n                <thead>\r\n                    <tr>\r\n                        <th scope=\"col\">\r\n                            ");
#nullable restore
#line 20 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n\r\n                        <th scope=\"col\">\r\n                            ");
#nullable restore
#line 24 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Creditos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th scope=\"col\">\r\n                            Opciones\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 32 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
                     foreach (var item in Model.LstCurso) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 35 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
                           Write(Html.DisplayFor(item1 => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 38 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
                           Write(Html.DisplayFor(item1 => item.Creditos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 41 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
                           Write(Html.ActionLink("Editar", "edit", "curso", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                /\r\n                                ");
#nullable restore
#line 43 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
                           Write(Html.ActionLink("Eliminar", "delete", "curso", new { id = item.Id }, new { onclick = "return confirm('Are you sure you want to delete?')" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                /\r\n                                ");
#nullable restore
#line 45 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
                           Write(Html.ActionLink("Agregar comunicado", "comunicadoCurso", "curso", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                /\r\n                                ");
#nullable restore
#line 47 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
                           Write(Html.ActionLink("Ver comunicados", "listarComunicados", "curso", new { idCurso = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 50 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n\r\n            </table>\r\n        </fieldset>\r\n");
#nullable restore
#line 55 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</center>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Presentacion.Models.CursoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
