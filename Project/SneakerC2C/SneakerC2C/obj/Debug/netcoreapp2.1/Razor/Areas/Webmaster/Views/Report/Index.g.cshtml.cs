#pragma checksum "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "735e2884c6ea80741931e008e0076e4a1278554a"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"735e2884c6ea80741931e008e0076e4a1278554a", @"/Areas/Webmaster/Views/Report/Index.cshtml")]
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a2078901b704b06a2c3b26eb3180a22", async() => {
                BeginContext(151, 53, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <title>In đơn hàng ");
                EndContext();
                BeginContext(205, 17, false);
#line 9 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                  Write(ViewBag.MaDonHang);

#line default
#line hidden
                EndContext();
                BeginContext(222, 14, true);
                WriteLiteral("</title>\r\n    ");
                EndContext();
                BeginContext(236, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8a66d68a5f28407c839e95a1f0affd39", async() => {
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
            BeginContext(310, 4391, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24a573066ac344e39ebe5b25a6ddc83a", async() => {
                BeginContext(316, 70, true);
                WriteLiteral("\r\n    <header class=\"clearfix\">\r\n        <div id=\"logo\">\r\n            ");
                EndContext();
                BeginContext(386, 29, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2dbfc130055046168330e39e544709ad", async() => {
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
#line 29 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                        Write(ViewBag.Ten);

#line default
#line hidden
                EndContext();
                BeginContext(876, 38, true);
                WriteLiteral("</h2>\r\n            <div class=\"phone\">");
                EndContext();
                BeginContext(915, 11, false);
#line 30 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                          Write(ViewBag.SDT);

#line default
#line hidden
                EndContext();
                BeginContext(926, 41, true);
                WriteLiteral("</div>\r\n            <div class=\"address\">");
                EndContext();
                BeginContext(968, 14, false);
#line 31 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                            Write(ViewBag.DiaChi);

#line default
#line hidden
                EndContext();
                BeginContext(982, 39, true);
                WriteLiteral("</div>\r\n            <div class=\"email\">");
                EndContext();
                BeginContext(1022, 13, false);
#line 32 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                          Write(ViewBag.Email);

#line default
#line hidden
                EndContext();
                BeginContext(1035, 68, true);
                WriteLiteral("</div>\r\n        </div>\r\n        <div id=\"invoice\">\r\n            <h1>");
                EndContext();
                BeginContext(1104, 17, false);
#line 35 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
           Write(ViewBag.MaDonHang);

#line default
#line hidden
                EndContext();
                BeginContext(1121, 54, true);
                WriteLiteral("</h1>\r\n            <div class=\"date\"><b>Ngày Tạo:</b> ");
                EndContext();
                BeginContext(1176, 15, false);
#line 36 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                          Write(ViewBag.NgayTao);

#line default
#line hidden
                EndContext();
                BeginContext(1191, 8, true);
                WriteLiteral("</div>\r\n");
                EndContext();
#line 37 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
             if (ViewBag.NgayGiao != null)
            {

#line default
#line hidden
                BeginContext(1258, 52, true);
                WriteLiteral("                <div class=\"date\"><b>Ngày Giao:</b> ");
                EndContext();
                BeginContext(1311, 16, false);
#line 39 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                               Write(ViewBag.NgayGiao);

#line default
#line hidden
                EndContext();
                BeginContext(1327, 8, true);
                WriteLiteral("</div>\r\n");
                EndContext();
#line 40 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
            }

#line default
#line hidden
                BeginContext(1350, 30, true);
                WriteLiteral("        </div>\r\n    </div>\r\n\r\n");
                EndContext();
#line 44 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
      

        int stt = 1;
        int stt_merchant = 0;
        double thanhtien = 0;
        double tongtienchuaship = 0;
        //int check_footer = -1;
        string shop_name = "null_temp";
        string shop_sdt = "null_temp";
        string shop_address = "null_temp";
    

#line default
#line hidden
                BeginContext(1678, 365, true);
                WriteLiteral(@"
    <table border=""0"" cellspacing=""0"" cellpadding=""0"">
        <thead>
            <tr>
                <th class=""no"">STT</th>
                <th class=""no"">Tên Sản Phẩm/Shop</th>
                <th class=""no"">Đơn Giá</th>
                <th class=""no"">Số Lượng</th>
                <th class=""no"">Thành Tiền</th>
            </tr>
        </thead>
");
                EndContext();
#line 66 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
         foreach (var item in Model)
        {
            //check_footer = 0;

            

#line default
#line hidden
#line 70 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
             if (shop_name != item.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenShop)
            {
                stt_merchant++;
                //check_footer = 1
                shop_name = item.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenShop;
                shop_sdt = item.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.DienThoai;

                //tongtienchuaship = 0;
                stt = 1;

#line default
#line hidden
                BeginContext(2607, 96, true);
                WriteLiteral("                <tbody>\r\n                    <tr>\r\n                        <th class=\"unit\"><h2>");
                EndContext();
                BeginContext(2704, 12, false);
#line 81 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                        Write(stt_merchant);

#line default
#line hidden
                EndContext();
                BeginContext(2716, 113, true);
                WriteLiteral(".</h2></th>\r\n                        <th class=\"unit\" style=\"text-align:left\"><h2>Shop: &nbsp;&nbsp;&nbsp;&nbsp; ");
                EndContext();
                BeginContext(2830, 9, false);
#line 82 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                                                               Write(shop_name);

#line default
#line hidden
                EndContext();
                BeginContext(2839, 3, true);
                WriteLiteral(" - ");
                EndContext();
                BeginContext(2843, 8, false);
#line 82 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                                                                            Write(shop_sdt);

#line default
#line hidden
                EndContext();
                BeginContext(2851, 237, true);
                WriteLiteral(" </h2></th>\r\n                        <th class=\"unit\"><h3></h3></th>\r\n                        <th class=\"unit\"><h3></h3></th>\r\n                        <th class=\"unit\"><h3></h3></th>\r\n                    </tr>\r\n                </tbody>\r\n");
                EndContext();
#line 88 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                
            }

#line default
#line hidden
                BeginContext(3123, 106, true);
                WriteLiteral("            <tbody>\r\n                <tr>\r\n                    <td class=\"desc\" style=\"text-align:center\">");
                EndContext();
                BeginContext(3230, 12, false);
#line 93 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                          Write(stt_merchant);

#line default
#line hidden
                EndContext();
                BeginContext(3242, 3, true);
                WriteLiteral(" . ");
                EndContext();
                BeginContext(3246, 3, false);
#line 93 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                                          Write(stt);

#line default
#line hidden
                EndContext();
                BeginContext(3249, 84, true);
                WriteLiteral("</td>\r\n                    <td class=\"desc\" style=\"text-decoration-color:black\"><h3>");
                EndContext();
                BeginContext(3334, 59, false);
#line 94 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                                        Write(item.IdSizeSanPhamNavigation.IdSanPhamNavigation.TenSanPham);

#line default
#line hidden
                EndContext();
                BeginContext(3393, 75, true);
                WriteLiteral("</h3></td>\r\n                    <td class=\"desc\" style=\"text-align:center\">");
                EndContext();
                BeginContext(3469, 35, false);
#line 95 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                          Write(item.DonGia.Value.ToString("#,###"));

#line default
#line hidden
                EndContext();
                BeginContext(3504, 71, true);
                WriteLiteral("đ</td>\r\n                    <td class=\"desc\" style=\"text-align:center\">");
                EndContext();
                BeginContext(3576, 12, false);
#line 96 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                          Write(item.SoLuong);

#line default
#line hidden
                EndContext();
                BeginContext(3588, 7, true);
                WriteLiteral("</td>\r\n");
                EndContext();
#line 97 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                      
                        thanhtien = item.DonGia.Value * item.SoLuong.Value;
                    

#line default
#line hidden
                BeginContext(3719, 62, true);
                WriteLiteral("                    <td class=\"desc\" style=\"text-align:right\">");
                EndContext();
                BeginContext(3782, 27, false);
#line 100 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                         Write(thanhtien.ToString("#,###"));

#line default
#line hidden
                EndContext();
                BeginContext(3809, 31, true);
                WriteLiteral("đ</td>\r\n                </tr>\r\n");
                EndContext();
#line 102 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                  
                    stt++;
                    tongtienchuaship = tongtienchuaship + thanhtien;
                

#line default
#line hidden
                BeginContext(3977, 22, true);
                WriteLiteral("            </tbody>\r\n");
                EndContext();
#line 107 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"

        }

#line default
#line hidden
                BeginContext(4012, 218, true);
                WriteLiteral("        <tfoot>\r\n            <tr>\r\n                <td colspan=\"2\"></td>\r\n                <td colspan=\"2\" style=\"text-align:right\"><h2>Tổng Tiền:</h2></td>\r\n                <td colspan=\"2\" style=\"text-align:right\"><h2>");
                EndContext();
                BeginContext(4231, 34, false);
#line 113 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Report\Index.cshtml"
                                                        Write(tongtienchuaship.ToString("#,###"));

#line default
#line hidden
                EndContext();
                BeginContext(4265, 429, true);
                WriteLiteral(@"đ</h2></td>
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
            BeginContext(4701, 9, true);
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
