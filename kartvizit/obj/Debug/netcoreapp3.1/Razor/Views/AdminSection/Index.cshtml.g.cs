#pragma checksum "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\AdminSection\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "890945930eb15d08062d47addd468ede76a5fb8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminSection_Index), @"mvc.1.0.view", @"/Views/AdminSection/Index.cshtml")]
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
#line 1 "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\_ViewImports.cshtml"
using kartvizit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\_ViewImports.cshtml"
using kartvizit.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"890945930eb15d08062d47addd468ede76a5fb8c", @"/Views/AdminSection/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66922c5f823653fb7c22aaaf18670122fb498b9d", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminSection_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\AdminSection\Index.cshtml"
  
    ViewData["Title"] = "YÖNETİCİ PANELİ";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<section class=""checkout-page"">
    <div class=""auto-container"">

        <!--Checkout Details-->
        <div class=""checkout-form"">
                <div class=""row clearfix"">
                    <!--Column-->
                    <div class=""column col-lg-12 col-md-12 col-sm-12"">
                        <div class=""inner-column"">
                            <div class=""sec-title"">
                                <h3>");
#nullable restore
#line 18 "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\AdminSection\Index.cshtml"
                               Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            </div>\r\n\r\n                            <div class=\"row\">\r\n                                <div class=\"col-md-4\">\r\n                                    <ul>\r\n");
            WriteLiteral("                                        <li><a");
            BeginWriteAttribute("href", " href=\"", 856, "\"", 897, 1);
#nullable restore
#line 25 "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\AdminSection\Index.cshtml"
WriteAttributeValue("", 863, Url.Action("AdminIndex","bolums"), 863, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Kategoriler ve Firmalar</a></li>\r\n                                        <li><a");
            BeginWriteAttribute("href", " href=\"", 979, "\"", 1025, 1);
#nullable restore
#line 26 "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\AdminSection\Index.cshtml"
WriteAttributeValue("", 986, Url.Action("ListUsers","AdminSection"), 986, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Tüm Kullanıcılar</a></li>
                                    </ul>

                                </div>
                            </div>


                        </div>
                    </div>
                </div>

        </div>
        <!--End Checkout Details-->
    </div>
</section>



















");
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
