#pragma checksum "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\Shared\_AdminPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce3e18a872c38e14fc2e3f83844cfd4807368a20"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AdminPartial), @"mvc.1.0.view", @"/Views/Shared/_AdminPartial.cshtml")]
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
#nullable restore
#line 1 "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\Shared\_AdminPartial.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce3e18a872c38e14fc2e3f83844cfd4807368a20", @"/Views/Shared/_AdminPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66922c5f823653fb7c22aaaf18670122fb498b9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AdminPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\Shared\_AdminPartial.cshtml"
 if (User.IsInRole("adminrole"))
{
    

#line default
#line hidden
#nullable disable
            WriteLiteral("<li><a");
            BeginWriteAttribute("href", " href=\"", 276, "\"", 318, 1);
#nullable restore
#line 8 "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\Shared\_AdminPartial.cshtml"
WriteAttributeValue("", 283, Url.Action("Index","AdminSection"), 283, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Adm</a></li>\r\n");
#nullable restore
#line 9 "C:\Users\asus\source\repos\Kartvizit\kartvizit\Views\Shared\_AdminPartial.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
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
