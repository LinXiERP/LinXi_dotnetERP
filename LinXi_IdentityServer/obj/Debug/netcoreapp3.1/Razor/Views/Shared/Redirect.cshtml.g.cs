<<<<<<< HEAD
#pragma checksum "E:\Net Core\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Redirect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e7509b3314193138178b3220fe97f86d523cf66"
=======
#pragma checksum "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Redirect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a0e2d4482a05bfa6a06032628e808d2725bf7a0"
>>>>>>> 3bd7e99fd7c98462bd8d12e516664a6fca97796a
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Redirect), @"mvc.1.0.view", @"/Views/Shared/Redirect.cshtml")]
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
#line 1 "E:\Net Core\LinXi_ERP\LinXi_IdentityServer\Views\_ViewImports.cshtml"
=======
#line 1 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\_ViewImports.cshtml"
>>>>>>> 3bd7e99fd7c98462bd8d12e516664a6fca97796a
using IdentityServerHost.Quickstart.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e7509b3314193138178b3220fe97f86d523cf66", @"/Views/Shared/Redirect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bec599faa2156b5976535a194fedf34093459faa", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Redirect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RedirectViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/signin-redirect.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"redirect-page\">\n    <div class=\"lead\">\n        <h1>You are now being returned to the application</h1>\n        <p>Once complete, you may close this tab.</p>\n    </div>\n</div>\n\n<meta http-equiv=\"refresh\"");
            BeginWriteAttribute("content", " content=\"", 239, "\"", 273, 2);
            WriteAttributeValue("", 249, "0;url=", 249, 6, true);
#nullable restore
<<<<<<< HEAD
#line 10 "E:\Net Core\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Redirect.cshtml"
WriteAttributeValue("", 255, Model.RedirectUrl, 255, 18, false);
=======
#line 10 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Redirect.cshtml"
WriteAttributeValue("", 264, Model.RedirectUrl, 264, 18, false);
>>>>>>> 3bd7e99fd7c98462bd8d12e516664a6fca97796a

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-url=\"");
#nullable restore
<<<<<<< HEAD
#line 10 "E:\Net Core\LinXi_ERP\LinXi_IdentityServer\Views\Shared\Redirect.cshtml"
=======
#line 10 "E:\ERP\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\Redirect.cshtml"
>>>>>>> 3bd7e99fd7c98462bd8d12e516664a6fca97796a
                                                                   Write(Model.RedirectUrl);

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
            WriteLiteral("\">\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e7509b3314193138178b3220fe97f86d523cf664246", async() => {
=======
            WriteLiteral("\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a0e2d4482a05bfa6a06032628e808d2725bf7a04268", async() => {
>>>>>>> 3bd7e99fd7c98462bd8d12e516664a6fca97796a
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RedirectViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
