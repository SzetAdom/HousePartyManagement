#pragma checksum "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\Drink\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbe2a27be46873dca47a25fda92d121fa9980e2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Drink_Index), @"mvc.1.0.view", @"/Views/Drink/Index.cshtml")]
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
#line 1 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\_ViewImports.cshtml"
using HousePartyManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\_ViewImports.cshtml"
using HousePartyManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbe2a27be46873dca47a25fda92d121fa9980e2b", @"/Views/Drink/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"073926d57a2e9d20dfad1887d879752c1cb42f66", @"/Views/_ViewImports.cshtml")]
    public class Views_Drink_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Drink>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\Drink\Index.cshtml"
  
    ViewData["Title"] = "Ital";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h1 class=\"display-4\">Italok</h1>\r\n</div>\r\n\r\n");
            WriteLiteral("\r\n<div>\r\n    <p></p>\r\n</div>\r\n\r\n<div>\r\n");
#nullable restore
#line 21 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\Drink\Index.cshtml"
     foreach (Drink drink in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
#nullable restore
#line 24 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\Drink\Index.cshtml"
   Write(drink.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 24 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\Drink\Index.cshtml"
                Write(drink.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 25 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\Drink\Index.cshtml"
         if (drink.AlcoholPercentage != 0)
        {

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\Drink\Index.cshtml"
    Write(drink.AlcoholString());

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\Drink\Index.cshtml"
                               
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 27 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\Drink\Index.cshtml"
     Write(drink.BottleString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" - \r\n        ");
#nullable restore
#line 28 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\Drink\Index.cshtml"
   Write(drink.PriceString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 30 "C:\Users\adams\Desktop\PROGMODGYAK\second\HousePartyManagement\HousePartyManagement\Views\Drink\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Drink>> Html { get; private set; }
    }
}
#pragma warning restore 1591
