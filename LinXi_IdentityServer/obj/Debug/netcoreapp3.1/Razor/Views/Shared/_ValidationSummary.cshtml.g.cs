<<<<<<< HEAD
#pragma checksum "G:\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\_ValidationSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4f205600e86668ece8138f7cea3c0d164a6cec5"
=======
#pragma checksum "E:\Net Core\LinXi_ERP\LinXi_IdentityServer\Views\Shared\_ValidationSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a23d835010b7aab5cf8b94c94a14392c4247b537"
>>>>>>> 6de42f00ffffc3f2242659b99b36b6b781f5d9b4
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ValidationSummary), @"mvc.1.0.view", @"/Views/Shared/_ValidationSummary.cshtml")]
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
#line 1 "G:\LinXi_dotnetERP\LinXi_IdentityServer\Views\_ViewImports.cshtml"
=======
#line 1 "E:\Net Core\LinXi_ERP\LinXi_IdentityServer\Views\_ViewImports.cshtml"
>>>>>>> 6de42f00ffffc3f2242659b99b36b6b781f5d9b4
using IdentityServerHost.Quickstart.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a23d835010b7aab5cf8b94c94a14392c4247b537", @"/Views/Shared/_ValidationSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bec599faa2156b5976535a194fedf34093459faa", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ValidationSummary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
<<<<<<< HEAD
#line 1 "G:\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\_ValidationSummary.cshtml"
=======
#line 1 "E:\Net Core\LinXi_ERP\LinXi_IdentityServer\Views\Shared\_ValidationSummary.cshtml"
>>>>>>> 6de42f00ffffc3f2242659b99b36b6b781f5d9b4
 if (ViewContext.ModelState.IsValid == false)
{

#line default
#line hidden
#nullable disable
<<<<<<< HEAD
            WriteLiteral("    <div class=\"alert alert-danger\">\r\n        <strong>Error</strong>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4f205600e86668ece8138f7cea3c0d164a6cec53601", async() => {
=======
            WriteLiteral("    <div class=\"alert alert-danger\">\n        <strong>Error</strong>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a23d835010b7aab5cf8b94c94a14392c4247b5373604", async() => {
>>>>>>> 6de42f00ffffc3f2242659b99b36b6b781f5d9b4
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
<<<<<<< HEAD
#line 5 "G:\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\_ValidationSummary.cshtml"
=======
#line 5 "E:\Net Core\LinXi_ERP\LinXi_IdentityServer\Views\Shared\_ValidationSummary.cshtml"
>>>>>>> 6de42f00ffffc3f2242659b99b36b6b781f5d9b4
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n");
#nullable restore
<<<<<<< HEAD
#line 7 "G:\LinXi_dotnetERP\LinXi_IdentityServer\Views\Shared\_ValidationSummary.cshtml"
=======
#line 7 "E:\Net Core\LinXi_ERP\LinXi_IdentityServer\Views\Shared\_ValidationSummary.cshtml"
>>>>>>> 6de42f00ffffc3f2242659b99b36b6b781f5d9b4
}

#line default
#line hidden
#nullable disable
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
