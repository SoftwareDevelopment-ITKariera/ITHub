#pragma checksum "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a3e2911d4fc4dece04791eafc21bd1cd1ce2e40"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Trips_List), @"mvc.1.0.view", @"/Views/Trips/List.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\_ViewImports.cshtml"
using DreamJourney;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\_ViewImports.cshtml"
using DreamJourney.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a3e2911d4fc4dece04791eafc21bd1cd1ce2e40", @"/Views/Trips/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba47e13930f21eb55cb20ecd6fed5cdbd7e0d97b", @"/Views/_ViewImports.cshtml")]
    public class Views_Trips_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DreamJourney.ViewModels.Trip.TripListViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Trips</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a3e2911d4fc4dece04791eafc21bd1cd1ce2e403789", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<div class=\"container\">\r\n");
#nullable restore
#line 10 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <hr>\r\n        <div class=\"row\">\r\n            <div class=\"container\">\r\n                <div class=\"row\">\r\n                    <h5>\r\n                        ");
#nullable restore
#line 17 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 19 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
                         if (Context.Session.GetInt32("loggedUserId").HasValue && Context.Session.GetInt32("loggedUserId").Value == item.UserId)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p style=\"font-size:12px\">\r\n                                ");
#nullable restore
#line 22 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
                           Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                ");
#nullable restore
#line 23 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
                           Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n");
#nullable restore
#line 25 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h5>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col-3\">\r\n                        <div class=\"w-100\">\r\n                            <img class=\"w-100\"");
            BeginWriteAttribute("src", " src=\"", 1141, "\"", 1191, 1);
#nullable restore
#line 32 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
WriteAttributeValue("", 1147, Html.DisplayFor(modelItem => item.ImageUrl), 1147, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                        </div>
                    </div>
                    <div class=""col-9"">
                        <div class=""container"">
                            <div class=""row"">
                                <p>
                                    <strong> ");
#nullable restore
#line 39 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
                                        Write(Html.DisplayFor(modelItem => item.Destinations));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong><br>\r\n                                    <i>Deparature on ");
#nullable restore
#line 40 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
                                                Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral(" for ");
#nullable restore
#line 40 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
                                                                                             Write(Html.DisplayFor(modelItem => item.Days));

#line default
#line hidden
#nullable disable
            WriteLiteral(" days.</i>\r\n                                </p>\r\n                            </div>\r\n                            <div class=\"row\">\r\n                                Organised by: &nbsp  ");
#nullable restore
#line 44 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
                                                Write(Html.DisplayFor(modelItem => item.UserFirstLastNames));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"row\">\r\n                                <p style=\"font-weight:bold\"><span style=\"float:right; margin:10px\">$ ");
#nullable restore
#line 47 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
                                                                                                Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></p>\r\n\r\n                            </div>\r\n                            <div class=\"row\">\r\n                                ");
#nullable restore
#line 51 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
                           Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 58 "C:\Users\sheydi\Desktop\IT_Kariera\DreamJourney_Repository\ITHub\DreamJourney\DreamJourney\Views\Trips\List.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DreamJourney.ViewModels.Trip.TripListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
