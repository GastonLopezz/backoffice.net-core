#pragma checksum "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75ab4bfd6cdd5d74f2e3aa1f6a4b848b3a7d2579"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Presentacion.Pages.Facultad.Views_Facultad_Edit), @"mvc.1.0.view", @"/Views/Facultad/Edit.cshtml")]
namespace Presentacion.Pages.Facultad
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75ab4bfd6cdd5d74f2e3aa1f6a4b848b3a7d2579", @"/Views/Facultad/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"182c3e91b32ea8a235c851f1e3419ceac5b361a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Facultad_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Presentacion.Models.FacultadViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Vertical", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Horizontal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Interno", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Google", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
Write(Html.ActionLink("Menú principal", "MenuAdminUdelar", "home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n|\r\n");
#nullable restore
#line 4 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
Write(Html.ActionLink("Facultad", "Index", "facultad"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n|\r\n");
#nullable restore
#line 6 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
Write(Html.ActionLink("Administrador", "Index", "administrador"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"padding:20px;\"></div>\r\n<legend>Editar Facultad</legend>\r\n<center>\r\n");
#nullable restore
#line 10 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
     using (Html.BeginForm()) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <fieldset style=\"width:200px;\">\r\n\r\n            <div style=\"padding:20px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 15 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.LabelFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 18 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.EditorFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 19 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Nombre, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 23 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.LabelFor(model => model.Abreviatura));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 26 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.EditorFor(model => model.Abreviatura));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 27 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Abreviatura, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 31 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.LabelFor(model => model.Url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 34 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.EditorFor(model => model.Url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 35 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Url, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 39 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.LabelFor(model => model.Logo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 42 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.EditorFor(model => model.Logo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 43 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Logo, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div class=\"editor-label\">\r\n                ");
#nullable restore
#line 47 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.LabelFor(model => model.Color));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"editor-field\">\r\n                ");
#nullable restore
#line 50 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.EditorFor(model => model.Color));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 51 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Color, "", new { @class = "custom_error" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div>\r\n                <select id=\"TipoNav\" name=\"TipoNav\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75ab4bfd6cdd5d74f2e3aa1f6a4b848b3a7d257911233", async() => {
                WriteLiteral("Selecionar Tipo Menú Nav");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75ab4bfd6cdd5d74f2e3aa1f6a4b848b3a7d257912742", async() => {
                WriteLiteral("Vertical");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75ab4bfd6cdd5d74f2e3aa1f6a4b848b3a7d257913924", async() => {
                WriteLiteral("Horizontal");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </select>\r\n            </div>\r\n            <div style=\"padding:5px;\"></div>\r\n            <div>\r\n                <select id=\"TipoAutenticacion\" name=\"TipoAutenticacion\">\r\n");
#nullable restore
#line 64 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
                     if (Model.Tipo_Autenticacion == "Interno") {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75ab4bfd6cdd5d74f2e3aa1f6a4b848b3a7d257915589", async() => {
                WriteLiteral("Interno");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75ab4bfd6cdd5d74f2e3aa1f6a4b848b3a7d257917085", async() => {
                WriteLiteral("Google");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 67 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
                    } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75ab4bfd6cdd5d74f2e3aa1f6a4b848b3a7d257918507", async() => {
                WriteLiteral("Interno");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75ab4bfd6cdd5d74f2e3aa1f6a4b848b3a7d257919692", async() => {
                WriteLiteral("Google");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 70 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n            </div>\r\n\r\n            ");
#nullable restore
#line 74 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
       Write(Html.HiddenFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"buttons\">\r\n                <br />\r\n                <input type=\"submit\" value=\"Editar\" />\r\n            </div>\r\n        </fieldset>\r\n");
#nullable restore
#line 80 "C:\Users\gasto\OneDrive\Escritorio\backoffice-.net-core\Presentacion\Views\Facultad\Edit.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Presentacion.Models.FacultadViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591