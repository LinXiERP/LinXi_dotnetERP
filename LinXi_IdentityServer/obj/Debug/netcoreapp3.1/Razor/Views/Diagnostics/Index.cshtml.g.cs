<<<<<<< HEAD
#pragma checksum "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df4cf1f1a739f1572e607b7045d8d314480aa991"
=======
<<<<<<< HEAD
#pragma checksum "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df4cf1f1a739f1572e607b7045d8d314480aa991"
=======
#pragma checksum "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df4cf1f1a739f1572e607b7045d8d314480aa991"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Diagnostics_Index), @"mvc.1.0.view", @"/Views/Diagnostics/Index.cshtml")]
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
<<<<<<< HEAD
#line 1 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\_ViewImports.cshtml"
=======
<<<<<<< HEAD
#line 1 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\_ViewImports.cshtml"
=======
#line 1 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\_ViewImports.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
using IdentityServerHost.Quickstart.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df4cf1f1a739f1572e607b7045d8d314480aa991", @"/Views/Diagnostics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a00496e1714fb62801584a343cc1019e13a800a", @"/Views/_ViewImports.cshtml")]
    public class Views_Diagnostics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DiagnosticsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""diagnostics-page"">
    <div class=""lead"">
        <h1>Authentication Cookie</h1>
    </div>

    <div class=""row"">
        <div class=""col"">
            <div class=""card"">
                <div class=""card-header"">
                    <h2>Claims</h2>
                </div>
                <div class=""card-body"">
                    <dl>
");
#nullable restore
<<<<<<< HEAD
#line 16 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 16 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 16 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                         foreach (var claim in Model.AuthenticateResult.Principal.Claims)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <dt>");
#nullable restore
<<<<<<< HEAD
#line 18 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 18 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 18 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                           Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n                            <dd>");
#nullable restore
<<<<<<< HEAD
#line 19 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 19 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 19 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                           Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
<<<<<<< HEAD
#line 20 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 20 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 20 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </dl>
                </div>
            </div>
        </div>
        
        <div class=""col"">
            <div class=""card"">
                <div class=""card-header"">
                    <h2>Properties</h2>
                </div>
                <div class=""card-body"">
                    <dl>
");
#nullable restore
<<<<<<< HEAD
#line 33 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 33 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 33 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                         foreach (var prop in Model.AuthenticateResult.Properties.Items)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <dt>");
#nullable restore
<<<<<<< HEAD
#line 35 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 35 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 35 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                           Write(prop.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n                            <dd>");
#nullable restore
<<<<<<< HEAD
#line 36 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 36 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 36 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                           Write(prop.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
<<<<<<< HEAD
#line 37 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 37 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 37 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                        }

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 38 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 38 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 38 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                         if (Model.Clients.Any())
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <dt>Clients</dt>\r\n                            <dd>\r\n");
#nullable restore
<<<<<<< HEAD
#line 42 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 42 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 42 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                              
                                var clients = Model.Clients.ToArray();
                                for(var i = 0; i < clients.Length; i++)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 46 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 46 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 46 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                                     Write(clients[i]);

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 46 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 46 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 46 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                                                            
                                    if (i < clients.Length - 1)
                                    {
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
<<<<<<< HEAD
#line 49 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 49 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 49 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                                                       
                                    }
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </dd>\r\n");
#nullable restore
<<<<<<< HEAD
#line 54 "D:\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
<<<<<<< HEAD
#line 54 "F:\erp项目\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
=======
#line 54 "D:\桌面文件及其他\LinXi_dotnetERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Diagnostics\Index.cshtml"
>>>>>>> 0770a63f1e752e08f4fae67ccd77c6bcfdbfa913
>>>>>>> 84b96621e1dcbef075f59588225baa386b346cc2
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </dl>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DiagnosticsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
