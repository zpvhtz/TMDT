#pragma checksum "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de4c902160db86c1e783fc4d3423c423892b954f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Merchant_Views_DonHang_DaGiao), @"mvc.1.0.view", @"/Areas/Merchant/Views/DonHang/DaGiao.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Merchant/Views/DonHang/DaGiao.cshtml", typeof(AspNetCore.Areas_Merchant_Views_DonHang_DaGiao))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de4c902160db86c1e783fc4d3423c423892b954f", @"/Areas/Merchant/Views/DonHang/DaGiao.cshtml")]
    public class Areas_Merchant_Views_DonHang_DaGiao : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Models.Database.DonHang>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Merchant", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "DonHang", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChoXuLy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChoLayHang", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DangGiao", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DaGiao", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetChiTiet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btnChiTiet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
  
    ViewData["Title"] = "DaXuLy";
    Layout = "~/Views/Shared/_MerchantManagementLayout.cshtml";

#line default
#line hidden
            BeginContext(208, 155, true);
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"customer_quanly\">\r\n        <div id=\"horizontalTab\">\r\n            <ul class=\"resp-tabs-list\">\r\n                ");
            EndContext();
            BeginContext(363, 91, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bea8b3f652d545d7903232e3c18495f6", async() => {
                BeginContext(432, 18, true);
                WriteLiteral("<li>Chờ xử lý</li>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(454, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(472, 97, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be01ff5eac1d4824a7fd19609cb17e65", async() => {
                BeginContext(544, 21, true);
                WriteLiteral("<li>Chờ lấy hàng</li>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(569, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(587, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c96fb7ae398441d1b3685383f42cf617", async() => {
                BeginContext(657, 18, true);
                WriteLiteral("<li>Đang giao</li>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(679, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(697, 123, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25d7e600144d49aea61ead1662c5ea45", async() => {
                BeginContext(765, 51, true);
                WriteLiteral("<li style=\"background-color: #fc636b\">Đã xử lý</li>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(820, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(930, 99, true);
            WriteLiteral("            </ul>\r\n            <div class=\"resp-tabs-container\">\r\n                <!--/tab_one-->\r\n");
            EndContext();
#line 22 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(1094, 402, true);
            WriteLiteral(@"                    <div class=""tab1"">
                        <div class=""form_donhang"">
                            <div class=""ql_donhang"">
                                <div class=""tenshop_donhang"">
                                    <div class=""sanpham_giohang"">
                                        <a href=""#"">
                                            <i class=""fa fa-user""></i>
");
            EndContext();
            BeginContext(1643, 75, true);
            WriteLiteral("                                            <div class=\"txtid-sanpham\"><h5>");
            EndContext();
            BeginContext(1719, 37, false);
#line 32 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                                                      Write(item.IdTaiKhoanNavigation.TenDangNhap);

#line default
#line hidden
            EndContext();
            BeginContext(1756, 227, true);
            WriteLiteral("</h5></div>\r\n                                        </a>\r\n                                    </div>\r\n                                    <div class=\"trangthai_donhang id_donhang\">\r\n                                        ID: ");
            EndContext();
            BeginContext(1984, 7, false);
#line 36 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                       Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1991, 48, true);
            WriteLiteral("\r\n\r\n                                    </div>\r\n");
            EndContext();
            BeginContext(2154, 78, true);
            WriteLiteral("                                </div>\r\n                                <hr>\r\n");
            EndContext();
#line 42 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                 foreach (var ct in ViewBag.ChiTiet)
                                {
                                    

#line default
#line hidden
#line 44 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                     if (ct.IdDonHangNavigation.MaDonHang == item.MaDonHang)
                                    {

#line default
#line hidden
            BeginContext(2470, 252, true);
            WriteLiteral("                                        <div class=\"thongtin_donhang\">\r\n                                            <div class=\"sanpham_giohang sp_donhang\">\r\n                                                <div class=\"hinh_sanpham_giohang hinh_donhang\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 2722, "\"", 2819, 3);
            WriteAttributeValue("", 2730, "background-image:url(/Hinh/SanPham/", 2730, 35, true);
#line 48 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
WriteAttributeValue("", 2765, ct.IdSizeSanPhamNavigation.IdSanPhamNavigation.Hinh, 2765, 52, false);

#line default
#line hidden
            WriteAttributeValue("", 2817, ");", 2817, 2, true);
            EndWriteAttribute();
            BeginContext(2820, 220, true);
            WriteLiteral("></div>\r\n                                                <div class=\"form_ten_sp_giohang ten_sp_donban\">\r\n                                                    <h5>\r\n                                                        ");
            EndContext();
            BeginContext(3041, 57, false);
#line 51 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                                   Write(ct.IdSizeSanPhamNavigation.IdSanPhamNavigation.TenSanPham);

#line default
#line hidden
            EndContext();
            BeginContext(3098, 253, true);
            WriteLiteral("\r\n                                                    </h5>\r\n                                                </div>\r\n                                                <div class=\"soluong_donban\">\r\n                                                    <h5>x ");
            EndContext();
            BeginContext(3352, 10, false);
#line 55 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                                     Write(ct.SoLuong);

#line default
#line hidden
            EndContext();
            BeginContext(3362, 280, true);
            WriteLiteral(@"</h5>
                                                </div>
                                                <div class=""donban_right"">
                                                    <div class=""tongtien_donban"">
                                                        đ ");
            EndContext();
            BeginContext(3643, 9, false);
#line 59 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                                     Write(ct.DonGia);

#line default
#line hidden
            EndContext();
            BeginContext(3652, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3749, 200, true);
            WriteLiteral("                                                    </div>\r\n                                                    <div class=\"trangthai_donban\">\r\n                                                        ");
            EndContext();
            BeginContext(3950, 19, false);
#line 63 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                                   Write(ct.TinhTrangChiTiet);

#line default
#line hidden
            EndContext();
            BeginContext(3969, 312, true);
            WriteLiteral(@"
                                                        <h6>Nhớ đánh giá người mua nhé.</h6>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
");
            EndContext();
#line 69 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                    }

#line default
#line hidden
#line 69 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                     
                                }

#line default
#line hidden
            BeginContext(4355, 301, true);
            WriteLiteral(@"                                <hr>
                                <div class=""chuthich_donban"">
                                    <div class=""chuthich_giaohang"">
                                        <div class=""button_donban"">
                                            <input type=""text""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4656, "\"", 4679, 1);
#line 75 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
WriteAttributeValue("", 4664, item.MaDonHang, 4664, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4680, 107, true);
            WriteLiteral(" class=\"value-madonhang\" readonly hidden />\r\n                                            <input type=\"text\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4787, "\"", 4803, 1);
#line 76 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
WriteAttributeValue("", 4795, item.Id, 4795, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4804, 89, true);
            WriteLiteral(" class=\"value-iddonhang\" readonly hidden />\r\n                                            ");
            EndContext();
            BeginContext(4893, 122, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ec802ec45f549afa5ac54e0803a61b0", async() => {
                BeginContext(5003, 8, true);
                WriteLiteral("Chi tiết");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 77 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                                                                                  WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5015, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(5189, 120, true);
            WriteLiteral("                                            <div class=\"donban_right\">\r\n                                                ");
            EndContext();
            BeginContext(5310, 13, false);
#line 80 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                                           Write(item.TongTien);

#line default
#line hidden
            EndContext();
            BeginContext(5323, 336, true);
            WriteLiteral(@"
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""clearfix""></div>
                    </div>
");
            EndContext();
#line 89 "C:\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\DonHang\DaGiao.cshtml"
                }

#line default
#line hidden
            BeginContext(5678, 60, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Models.Database.DonHang>> Html { get; private set; }
    }
}
#pragma warning restore 1591
