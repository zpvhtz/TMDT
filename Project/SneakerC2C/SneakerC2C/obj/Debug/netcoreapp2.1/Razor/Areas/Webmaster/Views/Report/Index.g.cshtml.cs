#pragma checksum "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e7c1dd40c5bc4cff96bad00334722d46d6a11e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Webmaster_Views_Report_Index), @"mvc.1.0.view", @"/Areas/Webmaster/Views/Report/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Webmaster/Views/Report/Index.cshtml", typeof(AspNetCore.Areas_Webmaster_Views_Report_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e7c1dd40c5bc4cff96bad00334722d46d6a11e3", @"/Areas/Webmaster/Views/Report/Index.cshtml")]
    public class Areas_Webmaster_Views_Report_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Models.Database.ChiTietDonHang>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/report/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("media", new global::Microsoft.AspNetCore.Html.HtmlString("all"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/report/logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(108, 37, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            EndContext();
            BeginContext(145, 142, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e3426bd644384a2e8091c5d32ff3a7ea", async() => {
                BeginContext(151, 64, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <title>Example 2</title>\r\n    ");
                EndContext();
                BeginContext(215, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "593fc04f7a7b4d6e98bac7b79efdf3cf", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(278, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(287, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(289, 2587, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "54f753e0bfef40cb83a8c7c9dadbef95", async() => {
                BeginContext(295, 70, true);
                WriteLiteral("\r\n    <header class=\"clearfix\">\r\n        <div id=\"logo\">\r\n            ");
                EndContext();
                BeginContext(365, 29, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ea7075ad32da480b987abc3b6ea52a2b", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(394, 463, true);
                WriteLiteral(@"
        </div>
        <div id=""company"">
            <h2 class=""name"">SneakersX</h2>
            <div>325/5 Hoà Hảo F4 Q10 TPHCM</div>
            <div>(08)34 673 896</div>
            <div class=""email"">snkrxemail@gmail.com</a></div>
        </div>
    </header>
    <main>

        <div id=""details"" class=""clearfix"">
            <div id=""client"">
                <div class=""to"">Thông Tin Người Mua Hàng:</div>
                <h2 class=""name"">");
                EndContext();
                BeginContext(858, 11, false);
#line 29 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                            Write(ViewBag.Ten);

#line default
#line hidden
                EndContext();
                BeginContext(869, 42, true);
                WriteLiteral("</h2>\r\n                <div class=\"phone\">");
                EndContext();
                BeginContext(912, 11, false);
#line 30 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                              Write(ViewBag.SDT);

#line default
#line hidden
                EndContext();
                BeginContext(923, 45, true);
                WriteLiteral("</div>\r\n                <div class=\"address\">");
                EndContext();
                BeginContext(969, 14, false);
#line 31 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                Write(ViewBag.DiaChi);

#line default
#line hidden
                EndContext();
                BeginContext(983, 43, true);
                WriteLiteral("</div>\r\n                <div class=\"email\">");
                EndContext();
                BeginContext(1027, 13, false);
#line 32 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                              Write(ViewBag.Email);

#line default
#line hidden
                EndContext();
                BeginContext(1040, 84, true);
                WriteLiteral("</a></div>\r\n            </div>\r\n            <div id=\"invoice\">\r\n                <h1>");
                EndContext();
                BeginContext(1125, 17, false);
#line 35 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
               Write(ViewBag.MaDonHang);

#line default
#line hidden
                EndContext();
                BeginContext(1142, 58, true);
                WriteLiteral("</h1>\r\n                <div class=\"date\"><b>Ngày Tạo:</b> ");
                EndContext();
                BeginContext(1201, 15, false);
#line 36 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                              Write(ViewBag.NgayTao);

#line default
#line hidden
                EndContext();
                BeginContext(1216, 60, true);
                WriteLiteral("</div>\r\n                <div class=\"date\"><b>Ngày Giao:</b> ");
                EndContext();
                BeginContext(1277, 16, false);
#line 37 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                               Write(ViewBag.NgayGiao);

#line default
#line hidden
                EndContext();
                BeginContext(1293, 466, true);
                WriteLiteral(@"</div>
            </div>
        </div>

            <table border=""0"" cellspacing=""0"" cellpadding=""0"">
                <thead>
                    <tr>
                        <th class=""no"">#</th>
                        <th class=""desc""><h3>Tên Sản Phẩm</h3></th>
                        <th class=""qty"">Đơn Giá</th>
                        <th class=""total"">Số Lượng</th>
                    </tr>
                </thead>
                <tbody>
");
                EndContext();
#line 51 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
                BeginContext(1832, 125, true);
                WriteLiteral("                        <tr>\r\n                            <td class=\"no\"></td>\r\n                            <td class=\"desc\">");
                EndContext();
                BeginContext(1958, 18, false);
#line 55 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                        Write(item.IdSizeSanPham);

#line default
#line hidden
                EndContext();
                BeginContext(1976, 52, true);
                WriteLiteral("</td>\r\n                            <td class=\"unit\">");
                EndContext();
                BeginContext(2029, 11, false);
#line 56 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                        Write(item.DonGia);

#line default
#line hidden
                EndContext();
                BeginContext(2040, 51, true);
                WriteLiteral("</td>\r\n                            <td class=\"qty\">");
                EndContext();
                BeginContext(2092, 12, false);
#line 57 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                       Write(item.SoLuong);

#line default
#line hidden
                EndContext();
                BeginContext(2104, 38, true);
                WriteLiteral("</td>\r\n                        </tr>\r\n");
                EndContext();
#line 59 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                    }

#line default
#line hidden
                BeginContext(2165, 704, true);
                WriteLiteral(@"                </tbody>
                <tfoot>
                    <tr>
                        <td colspan=""1""></td>
                        <td colspan=""2"">SUBTOTAL</td>
                        <td>$5,200.00</td>
                    </tr>

                </tfoot>
            </table>

        <div id=""thanks"">Cảm ơn bạn đã tin tưởng và sử dụng dịch vụ của chúng tôi!</div>
        <div id=""notices"">
            <div>Ghi chú:</div>
            <div class=""notice"">Hãy báo cáo cho đơn vị chúng tôi nếu bạn gặp vấn đề khi giao dịch</div>
        </div>
    </main>
    <footer>
        Invoice was created on a computer and is valid without the signature and seal.
    </footer>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2876, 9, true);
            WriteLiteral("\r\n</html>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Models.Database.ChiTietDonHang>> Html { get; private set; }
    }
}
#pragma warning restore 1591
