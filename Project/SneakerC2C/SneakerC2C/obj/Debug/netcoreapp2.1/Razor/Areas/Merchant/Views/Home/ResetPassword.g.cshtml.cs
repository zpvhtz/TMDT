#pragma checksum "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\Home\ResetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ec7ddcbfc31a01db0e57ea2a3b0760fcd8b63f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Merchant_Views_Home_ResetPassword), @"mvc.1.0.view", @"/Areas/Merchant/Views/Home/ResetPassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Merchant/Views/Home/ResetPassword.cshtml", typeof(AspNetCore.Areas_Merchant_Views_Home_ResetPassword))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#line 4 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\Home\ResetPassword.cshtml"
using Microsoft.AspNetCore.Mvc;

#line default
#line hidden
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 3 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\Home\ResetPassword.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ec7ddcbfc31a01db0e57ea2a3b0760fcd8b63f5", @"/Areas/Merchant/Views/Home/ResetPassword.cshtml")]
    public class Areas_Merchant_Views_Home_ResetPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.Database.TaiKhoan>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("resetForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/maintemplate/images/log_pic.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(" "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(104, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(160, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\Home\ResetPassword.cshtml"
  
    ViewData["Title"] = "ResetPassword";
    Layout = "~/Views/Shared/_MerchantLayout.cshtml";

#line default
#line hidden
            BeginContext(266, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 14 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\Home\ResetPassword.cshtml"
 if (Model.DatLaiMatKhau == 0)
{

#line default
#line hidden
            BeginContext(305, 39, true);
            WriteLiteral("    <script>\r\n        location.href = \"");
            EndContext();
            BeginContext(345, 27, false);
#line 17 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\Home\ResetPassword.cshtml"
                    Write(Url.Action("Index", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(372, 19, true);
            WriteLiteral("\";\r\n    </script>\r\n");
            EndContext();
#line 19 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\Home\ResetPassword.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(403, 850, true);
            WriteLiteral(@"    <!-- Modal đặt lại mật khẩu-->
    <div class=""modal fade"" id=""resetPassword"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog"">
            <!-- Modal content-->
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <button type=""button"" id=""btnCloseModal"" class=""close"" data-dismiss=""modal"">&times;</button>
                </div>
                <div class=""modal-body modal-body-sub_agile"">
                    <div class=""col-md-8 modal_body_left modal_body_left1"">
                        <h3 class=""agileinfo_sign"">Đặt lại mật khẩu</h3>
                        <div id=""alertForgotModal2"" style=""display: none;"">
                            <p style=""color: red;"" id=""alertContentForgotModal2"">Thông báo</p>
                        </div>
                        ");
            EndContext();
            BeginContext(1253, 1008, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3cb9026bf8a4429aba5ac83bcc32bbfd", async() => {
                BeginContext(1310, 944, true);
                WriteLiteral(@"
                            <div class=""styled-input"">
                                <input type=""password"" id=""matkhau1"" name=""matkhau"" pattern="".{8,}"" required oninvalid=""this.setCustomValidity('Mật khẩu chứa ít nhất 8 ký tự')"" onchange=""this.setCustomValidity('')"">
                                <label>Mật khẩu</label>
                                <span></span>
                            </div>
                            <div class=""styled-input"">
                                <input type=""password"" id=""matkhau2"" pattern="".{8,}"" required oninvalid=""this.setCustomValidity('Mật khẩu chứa ít nhất 8 ký tự')"" onchange=""this.setCustomValidity('')"">
                                <label>Nhập lại mật khẩu</label>
                                <span></span>
                            </div>
                            <input type=""submit"" id=""btnResetPassword"" value=""Đặt lại mật khẩu"">
                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2261, 1899, true);
            WriteLiteral(@"
                        <ul class=""social-nav model-3d-0 footer-social w3_agile_social top_agile_third"">
                            <li>
                                <a href=""#"" class=""facebook"">
                                    <div class=""front""><i class=""fa fa-facebook"" aria-hidden=""true""></i></div>
                                    <div class=""back""><i class=""fa fa-facebook"" aria-hidden=""true""></i></div>
                                </a>
                            </li>
                            <li>
                                <a href=""#"" class=""twitter"">
                                    <div class=""front""><i class=""fa fa-twitter"" aria-hidden=""true""></i></div>
                                    <div class=""back""><i class=""fa fa-twitter"" aria-hidden=""true""></i></div>
                                </a>
                            </li>
                            <li>
                                <a href=""#"" class=""instagram"">
                                   ");
            WriteLiteral(@" <div class=""front""><i class=""fa fa-instagram"" aria-hidden=""true""></i></div>
                                    <div class=""back""><i class=""fa fa-instagram"" aria-hidden=""true""></i></div>
                                </a>
                            </li>
                            <li>
                                <a href=""#"" class=""pinterest"">
                                    <div class=""front""><i class=""fa fa-linkedin"" aria-hidden=""true""></i></div>
                                    <div class=""back""><i class=""fa fa-linkedin"" aria-hidden=""true""></i></div>
                                </a>
                            </li>
                        </ul>
                        <div class=""clearfix""></div>

                    </div>
                    <div class=""col-md-4 modal_body_right modal_body_right1"">
                        ");
            EndContext();
            BeginContext(4160, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aa77a6f7ab98497ab2d1875092d61953", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4215, 212, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"clearfix\"></div>\r\n                </div>\r\n            </div>\r\n            <!-- //Modal content-->\r\n        </div>\r\n    </div>\r\n    <!-- //Modal3 -->\r\n");
            EndContext();
#line 88 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\Home\ResetPassword.cshtml"
}

#line default
#line hidden
            BeginContext(4430, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4449, 337, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function(){
            $(""#resetPassword"").modal({
                show: true,
                backdrop: 'static',
                keyboard: false //prevent closing with Esc button
            });
        });

        $(""#btnCloseModal"").click(function(){
            location.href = """);
                EndContext();
                BeginContext(4787, 27, false);
#line 101 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\Home\ResetPassword.cshtml"
                        Write(Url.Action("Index", "Home"));

#line default
#line hidden
                EndContext();
                BeginContext(4814, 484, true);
                WriteLiteral(@""";
        });

        $(""#resetForm"").submit(function (e) {
            e.preventDefault();
            let matkhau1 = $(""#matkhau1"").val();
            let matkhau2 = $(""#matkhau2"").val();
            if(matkhau1 != matkhau2)
            {
                $(""#alertContentForgotModal2"").text(""Mật khẩu không trùng khớp"");
                $(""#alertForgotModal2"").css('display', 'block');
            }
            else
            {
                let tendangnhap = """);
                EndContext();
                BeginContext(5299, 17, false);
#line 115 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\Home\ResetPassword.cshtml"
                              Write(Model.TenDangNhap);

#line default
#line hidden
                EndContext();
                BeginContext(5316, 296, true);
                WriteLiteral(@""";
                $.ajax({
                    url: ""/Merchant/TaiKhoan/ResetPassword"",
                    type: ""post"",
                    data: { ""tendangnhap"": tendangnhap, ""matkhau"": matkhau1 },
                    success: function (data) {
                        location.href = """);
                EndContext();
                BeginContext(5613, 73, false);
#line 121 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\Home\ResetPassword.cshtml"
                                    Write(Url.Action("Index", "Home", new { thongbao = "Đổi mật khẩu thành công" }));

#line default
#line hidden
                EndContext();
                BeginContext(5686, 211, true);
                WriteLiteral("\";\r\n                    },\r\n                    error: function (data) {\r\n                        alert(\"Error: \" + data);\r\n                    }\r\n                });\r\n            }\r\n        });\r\n    </script>\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.Database.TaiKhoan> Html { get; private set; }
    }
}
#pragma warning restore 1591
