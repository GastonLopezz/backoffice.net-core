#pragma checksum "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b92a415152562c5682195ef27a5880611c100fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Presentacion.Pages.Curso.Views_Curso_Add), @"mvc.1.0.view", @"/Views/Curso/Add.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b92a415152562c5682195ef27a5880611c100fa", @"/Views/Curso/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"182c3e91b32ea8a235c851f1e3419ceac5b361a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Curso_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Presentacion.Models.CursoViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
Write(Html.ActionLink("Menú principal", "MenuAdminFacu", "home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    |\r\n");
#nullable restore
#line 4 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
Write(Html.ActionLink("Docentes", "Index", "docente"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    |\r\n");
#nullable restore
#line 6 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
Write(Html.ActionLink("Cursos", "Index", "curso"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"padding:20px;\"></div>\r\n<legend>Crear un nuevo Curso</legend>\r\n<center>\r\n");
#nullable restore
#line 10 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
     using (Html.BeginForm()) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <fieldset style=\"width:200px;\">\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 13 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.LabelFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 16 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.TextBoxFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 17 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Nombre, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 21 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.LabelFor(model => model.Creditos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 24 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.EditorFor(model => model.Creditos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 25 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Creditos, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 29 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.LabelFor(model => model.Year_Diactado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 32 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.EditorFor(model => model.Year_Diactado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 33 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Year_Diactado, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 37 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.LabelFor(model => model.Informacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 40 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.EditorFor(model => model.Informacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 41 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Informacion, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 45 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.LabelFor(model => model.Nota_Minima_Aprobacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 48 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.EditorFor(model => model.Nota_Minima_Aprobacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 49 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Nota_Minima_Aprobacion, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 53 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.LabelFor(model => model.Nota_Maxima_Aprobacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 56 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.EditorFor(model => model.Nota_Maxima_Aprobacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 57 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Nota_Maxima_Aprobacion, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 61 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.LabelFor(model => model.Nota_Minima_Examen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 64 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.EditorFor(model => model.Nota_Minima_Examen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 65 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Nota_Minima_Examen, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 69 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.LabelFor(model => model.Nota_Maxima_Examen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 72 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.EditorFor(model => model.Nota_Maxima_Examen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 73 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
           Write(Html.ValidationMessageFor(model => model.Nota_Maxima_Examen, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <br />\r\n            <div class=\"buttons\">\r\n                <div>\r\n                    <input type=\"submit\" value=\"Agregar\" />\r\n                </div>\r\n            </div>\r\n\r\n        </fieldset>\r\n");
#nullable restore
#line 83 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Curso\Add.cshtml"
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
