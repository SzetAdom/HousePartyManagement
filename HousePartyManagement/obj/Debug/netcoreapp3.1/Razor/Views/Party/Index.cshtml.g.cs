#pragma checksum "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb9285132aa238cb3d4c0098f1708a25016ffa5e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Party_Index), @"mvc.1.0.view", @"/Views/Party/Index.cshtml")]
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
#line 1 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\_ViewImports.cshtml"
using HousePartyManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\_ViewImports.cshtml"
using HousePartyManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb9285132aa238cb3d4c0098f1708a25016ffa5e", @"/Views/Party/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33e8170142a264a15f85613cea9df9a37a7b6708", @"/Views/_ViewImports.cshtml")]
    public class Views_Party_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Party>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowCreate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "More", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
  
    ViewData["Title"] = "Party";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div>\n    <h1 class=\"display-4\">Bulik</h1>\n</div>\n\n\n<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb9285132aa238cb3d4c0098f1708a25016ffa5e4373", async() => {
                WriteLiteral("Létrehoz");
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
            WriteLiteral("\n    <hr>\n</div>\n\n<div>\n");
#nullable restore
#line 18 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
     foreach (Party party in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>Szervező: ");
#nullable restore
#line 20 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
                Write(party.Host);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        <p>Helyszín: ");
#nullable restore
#line 21 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
                Write(party.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        <p>Dátum: ");
#nullable restore
#line 22 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
             Write(party.Time.ToString("yyyy-MM-dd HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
            WriteLiteral("        <table>\n            <tr>\n                <th>Jelentkezők:</th>\n            </tr>\n");
#nullable restore
#line 28 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
             foreach (string member in party.Members)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 31 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
                   Write(member);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                </tr>\n");
#nullable restore
#line 33 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\n");
            WriteLiteral("        <p>Kapacitás: ");
#nullable restore
#line 36 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
                 Write(party.Members.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 36 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
                                        Write(party.Capacity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb9285132aa238cb3d4c0098f1708a25016ffa5e8258", async() => {
                WriteLiteral("Bővebben");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
                               WriteLiteral(party.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 39 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
         if (party.Host == User.Identity.Name)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb9285132aa238cb3d4c0098f1708a25016ffa5e10699", async() => {
                WriteLiteral("Szerkeszt");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
                                       WriteLiteral(party.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 42 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <hr>\n");
#nullable restore
#line 45 "C:\Users\adams\Documents\GitHub\HousePartyManagement\HousePartyManagement\Views\Party\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Party>> Html { get; private set; }
    }
}
#pragma warning restore 1591
