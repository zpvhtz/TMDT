#pragma checksum "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "426686b6d143a79c4cc1f70fe34dbae8757de195"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Merchant_Views_QuanLy_ConHang), @"mvc.1.0.view", @"/Areas/Merchant/Views/QuanLy/ConHang.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Merchant/Views/QuanLy/ConHang.cshtml", typeof(AspNetCore.Areas_Merchant_Views_QuanLy_ConHang))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"426686b6d143a79c4cc1f70fe34dbae8757de195", @"/Areas/Merchant/Views/QuanLy/ConHang.cshtml")]
    public class Areas_Merchant_Views_QuanLy_ConHang : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Models.Database.SanPham>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Merchant", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "QuanLy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListSP", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ConHang", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "HetHang", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "KhoaSP", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
  
    ViewData["Title"] = "ConHang";
    Layout = "~/Views/Shared/_MerchantManagementLayout.cshtml";

#line default
#line hidden
            BeginContext(207, 176, true);
            WriteLiteral("\r\n<div class=\"new_arrivals_agile_w3ls_info menu-qlsp\">\r\n    <div class=\"container\">\r\n        <div id=\"horizontalTab\">\r\n            <ul class=\"resp-tabs-list\">\r\n                ");
            EndContext();
            BeginContext(383, 86, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "697f8473de564df6b4f6ecb08184eeaa", async() => {
                BeginContext(450, 15, true);
                WriteLiteral("<li>Tất cả</li>");
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
            BeginContext(469, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(487, 123, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5527fbba13344a9f9132395e6c341657", async() => {
                BeginContext(555, 51, true);
                WriteLiteral("<li style=\"background-color: #fc636b\">còn hàng</li>");
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
            BeginContext(610, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(628, 89, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa8560a960404c1b8dccdeaba4b35bc9", async() => {
                BeginContext(696, 17, true);
                WriteLiteral("<li>hết hàng</li>");
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
            BeginContext(717, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(735, 90, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b502e78a166469dbd43adb97fb4fe78", async() => {
                BeginContext(802, 19, true);
                WriteLiteral("<li>đã bị khoá</li>");
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
            BeginContext(825, 108, true);
            WriteLiteral("\r\n            </ul>\r\n            <div class=\"col-md-4 header-middle fix_timkiem_merchant\">\r\n                ");
            EndContext();
            BeginContext(933, 254, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "943a57413d514bfba9b7f96c17f1d91b", async() => {
                BeginContext(964, 216, true);
                WriteLiteral("\r\n                    <input type=\"search\" name=\"search\" placeholder=\"Tìm kiếm...\" required=\"\">\r\n                    <input type=\"submit\" value=\" \">\r\n                    <div class=\"clearfix\"></div>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1187, 845, true);
            WriteLiteral(@"
            </div>
            <div class=""resp-tabs-container"">
                <!--/tab_one-->
                <div class=""tab1"">
                    <div class=""col-md-3 product-men margin_merchant"">
                        <div class=""men-pro-item simpleCart_shelfItem"" style=""padding:0;"">
                            <a href=""#"" style=""text-decoration: none;"">
                                <div class=""them_sanpham"">
                                    <div class=""icon_themsp"">
                                        <i class=""fa fa-plus-circle"" style=""font-size:66px;""></i>
                                        <h4>Thêm 1 sản phẩm mới</h4>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
");
            EndContext();
#line 39 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                      
                        int i = 1;
                    

#line default
#line hidden
            BeginContext(2115, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 42 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                     foreach (var item in Model)
                    {
                        if (i <= 3)
                        {

#line default
#line hidden
            BeginContext(2252, 366, true);
            WriteLiteral(@"                            <div class=""col-md-3 product-men margin_merchant"">
                                <div class=""men-pro-item simpleCart_shelfItem"">
                                    <div class=""men-thumb-item"">
                                        <div class=""men-thumb-item"">
                                            <div class=""anhsanpham-3""");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 2618, "\"", 2674, 4);
            WriteAttributeValue("", 2626, "background-image:", 2626, 17, true);
            WriteAttributeValue(" ", 2643, "url(/Hinh/SanPham/", 2644, 19, true);
#line 50 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
WriteAttributeValue("", 2662, item.Hinh, 2662, 10, false);

#line default
#line hidden
            WriteAttributeValue("", 2672, ");", 2672, 2, true);
            EndWriteAttribute();
            BeginContext(2675, 260, true);
            WriteLiteral(@"></div>
                                        </div>
                                    </div>
                                    <div class=""item-info-product "">
                                        <h4><a href=""single.html"" class=""tieude_sanpham"">");
            EndContext();
            BeginContext(2936, 15, false);
#line 54 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                                                                    Write(item.TenSanPham);

#line default
#line hidden
            EndContext();
            BeginContext(2951, 85, true);
            WriteLiteral("</a></h4>\r\n                                        <div class=\"info-product-price\">\r\n");
            EndContext();
#line 56 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                             if (item.GiamGia != null && item.GiamGia != 0)
                                            {
                                                double gia = item.Gia * (100 - item.GiamGia) / 100 ?? 0;

#line default
#line hidden
            BeginContext(3282, 76, true);
            WriteLiteral("                                                <p><span class=\"item_price\">");
            EndContext();
            BeginContext(3359, 21, false);
#line 59 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                                                       Write(gia.ToString("#,###"));

#line default
#line hidden
            EndContext();
            BeginContext(3380, 17, true);
            WriteLiteral(" đ</span> <del>- ");
            EndContext();
            BeginContext(3398, 32, false);
#line 59 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                                                                                              Write(item.Gia.Value.ToString("#,###"));

#line default
#line hidden
            EndContext();
            BeginContext(3430, 14, true);
            WriteLiteral(" đ</del></p>\r\n");
            EndContext();
#line 60 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
            BeginContext(3588, 76, true);
            WriteLiteral("                                                <p><span class=\"item_price\">");
            EndContext();
            BeginContext(3665, 32, false);
#line 63 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                                                       Write(item.Gia.Value.ToString("#,###"));

#line default
#line hidden
            EndContext();
            BeginContext(3697, 15, true);
            WriteLiteral(" đ</span></p>\r\n");
            EndContext();
#line 64 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                            }

#line default
#line hidden
            BeginContext(3759, 162, true);
            WriteLiteral("                                        </div>\r\n                                        <div class=\"button-sua-xoa\">\r\n                                            ");
            EndContext();
            BeginContext(3921, 397, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1af17541214e4eb9bdefd1be45286ab5", async() => {
                BeginContext(3927, 384, true);
                WriteLiteral(@"
                                                <input type=""button"" value=""Size"" class=""btnSize"" />
                                                <input type=""button"" value=""Sửa"" class=""button-sua"" onclick=""location.href='#'"" />
                                                <input type=""submit"" value=""Xoá"" class=""button-xoa"" />
                                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4318, 170, true);
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
            EndContext();
#line 76 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                            i++;
                        }
                        if (i == 4)
                        {

#line default
#line hidden
            BeginContext(4613, 58, true);
            WriteLiteral("                            <div class=\"clearfix\"></div>\r\n");
            EndContext();
#line 81 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                        }
                        if (i >= 4)
                        {
                            break;
                        }
                    }

#line default
#line hidden
            BeginContext(4848, 60, true);
            WriteLiteral("                </div>\r\n                <div class=\"tab1\">\r\n");
            EndContext();
#line 89 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                      
                        int j = 1;
                    

#line default
#line hidden
            BeginContext(4991, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 92 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                     foreach (var item in Model)
                    {
                        if (j < 4)
                        {
                            j++;
                            continue;
                        }
                        if (j >= 4)
                        {

#line default
#line hidden
            BeginContext(5291, 366, true);
            WriteLiteral(@"                            <div class=""col-md-3 product-men margin_merchant"">
                                <div class=""men-pro-item simpleCart_shelfItem"">
                                    <div class=""men-thumb-item"">
                                        <div class=""men-thumb-item"">
                                            <div class=""anhsanpham-3""");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 5657, "\"", 5713, 4);
            WriteAttributeValue("", 5665, "background-image:", 5665, 17, true);
            WriteAttributeValue(" ", 5682, "url(/Hinh/SanPham/", 5683, 19, true);
#line 105 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
WriteAttributeValue("", 5701, item.Hinh, 5701, 10, false);

#line default
#line hidden
            WriteAttributeValue("", 5711, ");", 5711, 2, true);
            EndWriteAttribute();
            BeginContext(5714, 260, true);
            WriteLiteral(@"></div>
                                        </div>
                                    </div>
                                    <div class=""item-info-product "">
                                        <h4><a href=""single.html"" class=""tieude_sanpham"">");
            EndContext();
            BeginContext(5975, 15, false);
#line 109 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                                                                    Write(item.TenSanPham);

#line default
#line hidden
            EndContext();
            BeginContext(5990, 85, true);
            WriteLiteral("</a></h4>\r\n                                        <div class=\"info-product-price\">\r\n");
            EndContext();
#line 111 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                             if (item.GiamGia != null && item.GiamGia != 0)
                                            {
                                                double gia = item.Gia * (100 - item.GiamGia) / 100 ?? 0;

#line default
#line hidden
            BeginContext(6321, 76, true);
            WriteLiteral("                                                <p><span class=\"item_price\">");
            EndContext();
            BeginContext(6398, 21, false);
#line 114 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                                                       Write(gia.ToString("#,###"));

#line default
#line hidden
            EndContext();
            BeginContext(6419, 17, true);
            WriteLiteral(" đ</span> <del>- ");
            EndContext();
            BeginContext(6437, 32, false);
#line 114 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                                                                                              Write(item.Gia.Value.ToString("#,###"));

#line default
#line hidden
            EndContext();
            BeginContext(6469, 14, true);
            WriteLiteral(" đ</del></p>\r\n");
            EndContext();
#line 115 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
            BeginContext(6627, 76, true);
            WriteLiteral("                                                <p><span class=\"item_price\">");
            EndContext();
            BeginContext(6704, 32, false);
#line 118 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                                                       Write(item.Gia.Value.ToString("#,###"));

#line default
#line hidden
            EndContext();
            BeginContext(6736, 15, true);
            WriteLiteral(" đ</span></p>\r\n");
            EndContext();
#line 119 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                                            }

#line default
#line hidden
            BeginContext(6798, 162, true);
            WriteLiteral("                                        </div>\r\n                                        <div class=\"button-sua-xoa\">\r\n                                            ");
            EndContext();
            BeginContext(6960, 397, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae358af1982644ffb45d8b5dd2b9ab49", async() => {
                BeginContext(6966, 384, true);
                WriteLiteral(@"
                                                <input type=""button"" value=""Size"" class=""btnSize"" />
                                                <input type=""button"" value=""Sửa"" class=""button-sua"" onclick=""location.href='#'"" />
                                                <input type=""submit"" value=""Xoá"" class=""button-xoa"" />
                                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7357, 170, true);
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
            EndContext();
#line 131 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                            j++;
                            if (j % 4 == 0)
                            {

#line default
#line hidden
            BeginContext(7637, 62, true);
            WriteLiteral("                                <div class=\"clearfix\"></div>\r\n");
            EndContext();
#line 135 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\ConHang.cshtml"
                            }
                        }
                    }

#line default
#line hidden
            BeginContext(7780, 877, true);
            WriteLiteral(@"                </div>
                <!--//tab_one-->
                <!--phân trang-->
                <ul class=""phantrang modal-1"" style=""padding-top: 1.5em;"">
                    <li><a href=""#"" class=""prev"">&laquo</a></li>
                    <li><a href=""#"" class=""active"">1</a></li>
                    <li> <a href=""#"">2</a></li>
                    <li> <a href=""#"">3</a></li>
                    <li> <a href=""#"">4</a></li>
                    <li> <a href=""#"">5</a></li>
                    <li> <a href=""#"">6</a></li>
                    <li> <a href=""#"">7</a></li>
                    <li> <a href=""#"">8</a></li>
                    <li> <a href=""#"">9</a></li>
                    <li><a href=""#"" class=""next"">&raquo;</a></li>
                </ul>
                <!--hết phân trang-->
            </div>
        </div>
    </div>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Models.Database.SanPham>> Html { get; private set; }
    }
}
#pragma warning restore 1591
