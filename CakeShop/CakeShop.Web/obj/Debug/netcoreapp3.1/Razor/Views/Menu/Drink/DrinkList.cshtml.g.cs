#pragma checksum "D:\An3Sem2\PAW\CakeShop\CakeShop\CakeShop.Web\Views\Menu\Drink\DrinkList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a81ad522929113fa1638cb8ebf59a93c5200123a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Menu_Drink_DrinkList), @"mvc.1.0.view", @"/Views/Menu/Drink/DrinkList.cshtml")]
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
#line 1 "D:\An3Sem2\PAW\CakeShop\CakeShop\CakeShop.Web\Views\_ViewImports.cshtml"
using CakeShop.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\An3Sem2\PAW\CakeShop\CakeShop\CakeShop.Web\Views\_ViewImports.cshtml"
using CakeShop.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a81ad522929113fa1638cb8ebf59a93c5200123a", @"/Views/Menu/Drink/DrinkList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49c65a41d19018d62e3cd4222575d4b82f8f0136", @"/Views/_ViewImports.cshtml")]
    public class Views_Menu_Drink_DrinkList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("layout-custom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\An3Sem2\PAW\CakeShop\CakeShop\CakeShop.Web\Views\Menu\Drink\DrinkList.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.Title = "DrinkList";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a81ad522929113fa1638cb8ebf59a93c5200123a3662", async() => {
                WriteLiteral("\r\n    <h1 class=\"font-custom\" style=\"text-align: center\">Our Drinks</h1>\r\n    <hr/>\r\n    <section class=\"cards\">\r\n        ");
#nullable restore
#line 9 "D:\An3Sem2\PAW\CakeShop\CakeShop\CakeShop.Web\Views\Menu\Drink\DrinkList.cshtml"
   Write(await Html.PartialAsync("~/Views/Menu/_Card.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        ");
#nullable restore
#line 10 "D:\An3Sem2\PAW\CakeShop\CakeShop\CakeShop.Web\Views\Menu\Drink\DrinkList.cshtml"
   Write(await Html.PartialAsync("~/Views/Menu/_Card.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        ");
#nullable restore
#line 11 "D:\An3Sem2\PAW\CakeShop\CakeShop\CakeShop.Web\Views\Menu\Drink\DrinkList.cshtml"
   Write(await Html.PartialAsync("~/Views/Menu/_Card.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </section>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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