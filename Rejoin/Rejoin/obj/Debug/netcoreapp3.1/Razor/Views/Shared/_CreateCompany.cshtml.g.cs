#pragma checksum "C:\Users\Code\Desktop\Rejoin-Job-Advertisement\Rejoin\Rejoin\Views\Shared\_CreateCompany.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d76df726189210abff62970284c28d54fa1d7de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CreateCompany), @"mvc.1.0.view", @"/Views/Shared/_CreateCompany.cshtml")]
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
#line 1 "C:\Users\Code\Desktop\Rejoin-Job-Advertisement\Rejoin\Rejoin\Views\_ViewImports.cshtml"
using Rejoin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Code\Desktop\Rejoin-Job-Advertisement\Rejoin\Rejoin\Views\_ViewImports.cshtml"
using Rejoin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Code\Desktop\Rejoin-Job-Advertisement\Rejoin\Rejoin\Views\_ViewImports.cshtml"
using Rejoin.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Code\Desktop\Rejoin-Job-Advertisement\Rejoin\Rejoin\Views\_ViewImports.cshtml"
using Rejoin.Injections;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d76df726189210abff62970284c28d54fa1d7de", @"/Views/Shared/_CreateCompany.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31085bcb7515f4e4d54e7915ea9852b8b55c91de", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CreateCompany : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("companyform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal-dialog"" role=""document"">
    <div class=""modal-content"">
        <div class=""modal-header"">
            <h5 class=""modal-title"">Şirkət məlumatlarını daxil et</h5>
            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                <span aria-hidden=""true"">&times;</span>
            </button>
        </div>
        <div class=""modal-body"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d76df726189210abff62970284c28d54fa1d7de5107", async() => {
                WriteLiteral(@"
                <div class=""row"">

                    <div class=""col-sm-6 col-md-6"">
                        <div class=""form-group"">
                            <label class=""form-label"">Şirkətin Adı</label>
                            <input name=""companyname"" type=""text"" class=""form-control"" placeholder=""Şirkətin Adı"">
                        </div>
                    </div>
                    <div class=""col-sm-6 col-md-6"">
                        <div class=""form-group"">
                            <label class=""form-label"">E-poçt</label>
                            <input name=""companyemail"" type=""email"" class=""form-control"" placeholder=""E-poçtAddress"" required>
                        </div>
                    </div>
                    <div class=""col-sm-6 col-md-6"">
                        <div class=""form-group mb-0"">
                            <label class=""form-label"">Telefon nömrəsi</label>
                            <input name=""companyphone"" type=""number"" class=""form-c");
                WriteLiteral(@"ontrol"" placeholder=""Telefon nömrəsi"" required>
                        </div>
                    </div>
                    <div class=""col-sm-6 col-md-6"">
                        <div class=""form-group mb-0"">
                            <label class=""form-label"">Ünvan</label>
                            <input name=""companyaddress"" type=""text"" class=""form-control"" placeholder=""Ünvan"">
                        </div>
                    </div>
                    <div class=""col-sm-6 col-md-6"">
                        <div class=""form-group mb-0"">
                            <label class=""form-label"">Veb sayt</label>
                            <input name=""companywebsite"" type=""text"" class=""form-control"" placeholder=""Veb sayt"">
                        </div>
                    </div>
                    <div class=""col-sm-6 col-md-6"">
                        <div class=""form-group mb-0"">
                            <label style=""margin-top:24px; width: 222px; margin-left: 12px"" class=""cust");
                WriteLiteral(@"om-file-label"">Şəkil yüklə</label>
                            <input name=""companyphoto"" type=""file"" class=""custom-file-input""/>
                        </div>
                    </div>
                    <div class=""col-sm-12 col-md-12 col-lg-12"">
                        <div class=""form-group text-dark"">
                            <label class=""form-label text-dark"">Məlumat</label>
                            <textarea name=""companyinfo"" class=""form-control"" rows=""5"" placeholder=""Məlumat"" required></textarea>
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-primary create-company"">Təsdiqlə</button>
                </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
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