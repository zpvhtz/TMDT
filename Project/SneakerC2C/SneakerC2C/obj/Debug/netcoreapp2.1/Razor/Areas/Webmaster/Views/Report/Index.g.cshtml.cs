#pragma checksum "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfc11d6fd716e680002830ad7bd6218b3dbd331b"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfc11d6fd716e680002830ad7bd6218b3dbd331b", @"/Areas/Webmaster/Views/Report/Index.cshtml")]
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
            BeginContext(145, 163, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d521b4953df4691b1c6ca0a4a46541d", async() => {
                BeginContext(151, 53, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <title>In đơn hàng ");
                EndContext();
                BeginContext(205, 17, false);
#line 9 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                  Write(ViewBag.MaDonHang);

#line default
#line hidden
                EndContext();
                BeginContext(222, 14, true);
                WriteLiteral("</title>\r\n    ");
                EndContext();
                BeginContext(236, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "07b9780204c246e1a48854d39b60331d", async() => {
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
                BeginContext(299, 2, true);
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
            BeginContext(308, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(310, 4364, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "753ceb6bd99946948642a2599aca3200", async() => {
                BeginContext(316, 70, true);
                WriteLiteral("\r\n    <header class=\"clearfix\">\r\n        <div id=\"logo\">\r\n            ");
                EndContext();
                BeginContext(386, 29, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d4b8d6a1c3114beda7d57739fd7506ad", async() => {
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
                BeginContext(415, 449, true);
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
                BeginContext(865, 11, false);
#line 29 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                        Write(ViewBag.Ten);

#line default
#line hidden
                EndContext();
                BeginContext(876, 38, true);
                WriteLiteral("</h2>\r\n            <div class=\"phone\">");
                EndContext();
                BeginContext(915, 11, false);
#line 30 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                          Write(ViewBag.SDT);

#line default
#line hidden
                EndContext();
                BeginContext(926, 41, true);
                WriteLiteral("</div>\r\n            <div class=\"address\">");
                EndContext();
                BeginContext(968, 14, false);
#line 31 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                            Write(ViewBag.DiaChi);

#line default
#line hidden
                EndContext();
                BeginContext(982, 39, true);
                WriteLiteral("</div>\r\n            <div class=\"email\">");
                EndContext();
                BeginContext(1022, 13, false);
#line 32 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                          Write(ViewBag.Email);

#line default
#line hidden
                EndContext();
                BeginContext(1035, 68, true);
                WriteLiteral("</div>\r\n        </div>\r\n        <div id=\"invoice\">\r\n            <h1>");
                EndContext();
                BeginContext(1104, 17, false);
#line 35 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
           Write(ViewBag.MaDonHang);

#line default
#line hidden
                EndContext();
                BeginContext(1121, 54, true);
                WriteLiteral("</h1>\r\n            <div class=\"date\"><b>Ngày Tạo:</b> ");
                EndContext();
                BeginContext(1176, 15, false);
#line 36 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                          Write(ViewBag.NgayTao);

#line default
#line hidden
                EndContext();
                BeginContext(1191, 8, true);
                WriteLiteral("</div>\r\n");
                EndContext();
#line 37 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
             if (ViewBag.NgayGiao != null)
            {

#line default
#line hidden
                BeginContext(1258, 52, true);
                WriteLiteral("                <div class=\"date\"><b>Ngày Giao:</b> ");
                EndContext();
                BeginContext(1311, 16, false);
#line 39 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                               Write(ViewBag.NgayGiao);

#line default
#line hidden
                EndContext();
                BeginContext(1327, 8, true);
                WriteLiteral("</div>\r\n");
                EndContext();
#line 40 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
            }

#line default
#line hidden
                BeginContext(1350, 30, true);
                WriteLiteral("        </div>\r\n    </div>\r\n\r\n");
                EndContext();
#line 44 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
      

        int stt = 1;
        double thanhtien = 0;
        double tongtienchuaship = 0;
        //int check_footer = -1;
        string shop_name = "null_temp";
        string shop_sdt = "null_temp";
        string shop_address = "null_temp";
    

#line default
#line hidden
                BeginContext(1647, 413, true);
                WriteLiteral(@"
    <table border=""0"" cellspacing=""0"" cellpadding=""0"">
        <thead>
            <tr>
                <th class=""no"">STT</th>
                <th class=""total""><h3>Tên Sản Phẩm/Shop</h3></th>
                <th class=""total""><h3>Đơn Giá</h3></th>
                <th class=""total""><h3>Số Lượng</h3></th>
                <th class=""total""><h3>Thành Tiền</h3></th>
            </tr>
        </thead>
");
                EndContext();
#line 65 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
         foreach (var item in Model)
        {
            //check_footer = 0;

            

#line default
#line hidden
#line 69 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
             if (shop_name != item.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenShop)
            {
                //check_footer = 1
                shop_name = item.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenShop;
                shop_sdt = item.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.DienThoai;

                //tongtienchuaship = 0;
                stt = 1;

#line default
#line hidden
                BeginContext(2591, 199, true);
                WriteLiteral("                <tbody>\r\n                    <tr>\r\n                        <th class=\"unit\"></th>\r\n                        <th class=\"unit\" style=\"text-align:left\"><h2>Shop: &nbsp;&nbsp;&nbsp;&nbsp; ");
                EndContext();
                BeginContext(2791, 9, false);
#line 80 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                                                               Write(shop_name);

#line default
#line hidden
                EndContext();
                BeginContext(2800, 3, true);
                WriteLiteral(" - ");
                EndContext();
                BeginContext(2804, 8, false);
#line 80 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                                                                            Write(shop_sdt);

#line default
#line hidden
                EndContext();
                BeginContext(2812, 237, true);
                WriteLiteral(" </h2></th>\r\n                        <th class=\"unit\"><h3></h3></th>\r\n                        <th class=\"unit\"><h3></h3></th>\r\n                        <th class=\"unit\"><h3></h3></th>\r\n                    </tr>\r\n                </tbody>\r\n");
                EndContext();
#line 86 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
            }
            else
            {
                //check_footer = 0;
            }

#line default
#line hidden
                BeginContext(3149, 106, true);
                WriteLiteral("            <tbody>\r\n                <tr>\r\n                    <td class=\"desc\" style=\"text-align:center\">");
                EndContext();
                BeginContext(3256, 3, false);
#line 93 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                          Write(stt);

#line default
#line hidden
                EndContext();
                BeginContext(3259, 48, true);
                WriteLiteral("</td>\r\n                    <th class=\"desc\"><h3>");
                EndContext();
                BeginContext(3308, 59, false);
#line 94 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                    Write(item.IdSizeSanPhamNavigation.IdSanPhamNavigation.TenSanPham);

#line default
#line hidden
                EndContext();
                BeginContext(3367, 75, true);
                WriteLiteral("</h3></th>\r\n                    <td class=\"desc\" style=\"text-align:center\">");
                EndContext();
                BeginContext(3443, 35, false);
#line 95 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                          Write(item.DonGia.Value.ToString("#,###"));

#line default
#line hidden
                EndContext();
                BeginContext(3478, 71, true);
                WriteLiteral("đ</td>\r\n                    <td class=\"desc\" style=\"text-align:center\">");
                EndContext();
                BeginContext(3550, 12, false);
#line 96 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                          Write(item.SoLuong);

#line default
#line hidden
                EndContext();
                BeginContext(3562, 7, true);
                WriteLiteral("</td>\r\n");
                EndContext();
#line 97 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                      
                        thanhtien = item.DonGia.Value * item.SoLuong.Value;
                    

#line default
#line hidden
                BeginContext(3693, 62, true);
                WriteLiteral("                    <td class=\"desc\" style=\"text-align:right\">");
                EndContext();
                BeginContext(3756, 27, false);
#line 100 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                         Write(thanhtien.ToString("#,###"));

#line default
#line hidden
                EndContext();
                BeginContext(3783, 31, true);
                WriteLiteral("đ</td>\r\n                </tr>\r\n");
                EndContext();
#line 102 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                  
                    stt++;
                    tongtienchuaship = tongtienchuaship + thanhtien;
                

#line default
#line hidden
                BeginContext(3951, 22, true);
                WriteLiteral("            </tbody>\r\n");
                EndContext();
#line 107 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"

        }

#line default
#line hidden
                BeginContext(3986, 217, true);
                WriteLiteral("        <tfoot>\r\n            <tr>\r\n                <td colspan=\"2\"></td>\r\n                <td colspan=\"2\" style=\"text-align:right\"><h3>Tổng Tiền:</h3></td>\r\n                <td colspan=\"2\"style=\"text-align:right\"><h3>");
                EndContext();
                BeginContext(4204, 34, false);
#line 113 "F:\Github stuffs\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                       Write(tongtienchuaship.ToString("#,###"));

#line default
#line hidden
                EndContext();
                BeginContext(4238, 429, true);
                WriteLiteral(@"đ</h3></td>
            </tr>
        </tfoot>
    </table>
    <table border=""0"" cellspacing=""0"" cellpadding=""0"">

    </table>












    <div id=""thanks"">Cảm ơn bạn đã tin tưởng và sử dụng dịch vụ của chúng tôi!</div>
    <div id=""notices"">
        <div>Ghi chú:</div>
        <div class=""notice"">Hãy báo cáo cho đơn vị chúng tôi nếu bạn gặp vấn đề khi giao dịch</div>
    </div>

    </main>

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
            BeginContext(4674, 9, true);
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
