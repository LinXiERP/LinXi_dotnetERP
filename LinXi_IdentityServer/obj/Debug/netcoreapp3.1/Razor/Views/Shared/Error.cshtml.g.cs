<<<<<<< HEAD
#pragma checksum "E:\NetCore\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdb11f526fa3e745190a5fc76f1006c086703380"
=======
#pragma checksum "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4f7144537d0c8c8176b0742665e0d12a9fe7320"
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
#line 1 "E:\NetCore\LinXi_ERP\LinXi_IdentityServer\Views\_ViewImports.cshtml"
=======
#line 1 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\_ViewImports.cshtml"
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
using IdentityServerHost.Quickstart.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4f7144537d0c8c8176b0742665e0d12a9fe7320", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a00496e1714fb62801584a343cc1019e13a800a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
<<<<<<< HEAD
#line 3 "E:\NetCore\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
=======
#line 3 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
  
    var error = Model?.Error?.Error;
    var errorDescription = Model?.Error?.ErrorDescription;
    var request_id = Model?.Error?.RequestId;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"error-page\">\r\n    <div class=\"lead\">\r\n        <h1>Error</h1>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-6\">\r\n            <div class=\"alert alert-danger\">\r\n                Sorry, there was an error\r\n\r\n");
#nullable restore
<<<<<<< HEAD
#line 19 "E:\NetCore\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
=======
#line 19 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
                 if (error != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <strong>\r\n                        <em>\r\n                            : ");
#nullable restore
<<<<<<< HEAD
#line 23 "E:\NetCore\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
=======
#line 23 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
                         Write(error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </em>\r\n                    </strong>\r\n");
#nullable restore
<<<<<<< HEAD
#line 26 "E:\NetCore\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
=======
#line 26 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557

                    if (errorDescription != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div>");
#nullable restore
<<<<<<< HEAD
#line 29 "E:\NetCore\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
=======
#line 29 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
                        Write(errorDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
<<<<<<< HEAD
#line 30 "E:\NetCore\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
=======
#line 30 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n");
#nullable restore
<<<<<<< HEAD
#line 34 "E:\NetCore\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
=======
#line 34 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
             if (request_id != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"request-id\">Request Id: ");
#nullable restore
<<<<<<< HEAD
#line 36 "E:\NetCore\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
=======
#line 36 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
                                               Write(request_id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
<<<<<<< HEAD
#line 37 "E:\NetCore\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
=======
#line 37 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Error.cshtml"
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
