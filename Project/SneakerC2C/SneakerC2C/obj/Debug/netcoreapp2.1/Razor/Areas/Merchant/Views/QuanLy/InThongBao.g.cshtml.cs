#pragma checksum "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\InThongBao.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe7c6347be931bd686126b2a06ea9b0bc7191a00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Merchant_Views_QuanLy_InThongBao), @"mvc.1.0.view", @"/Areas/Merchant/Views/QuanLy/InThongBao.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Merchant/Views/QuanLy/InThongBao.cshtml", typeof(AspNetCore.Areas_Merchant_Views_QuanLy_InThongBao))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe7c6347be931bd686126b2a06ea9b0bc7191a00", @"/Areas/Merchant/Views/QuanLy/InThongBao.cshtml")]
    public class Areas_Merchant_Views_QuanLy_InThongBao : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Models.Database.SizeSanPham>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(120, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(171, 407, true);
            WriteLiteral(@"

<h3>Những sản phẩm hết hàng</h3>
<table class=""table table-striped table-bordered table-hover"">
    <thead>
        <tr>
            <th style=""text-align: center; line-height: 74px;"">Tên sản phẩm</th>
            <th style=""text-align: center; line-height: 74px;"">Size</th>
            <th style=""text-align: center; line-height: 74px;"">Số lượng</th>
        </tr>
    </thead>

    <tbody>
");
            EndContext();
#line 18 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\InThongBao.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(627, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(674, 35, false);
#line 21 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\InThongBao.cshtml"
                   Write(item.IdSanPhamNavigation.TenSanPham);

#line default
#line hidden
            EndContext();
            BeginContext(709, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(741, 9, false);
#line 22 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\InThongBao.cshtml"
                   Write(item.Size);

#line default
#line hidden
            EndContext();
            BeginContext(750, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(782, 12, false);
#line 23 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\InThongBao.cshtml"
                   Write(item.SoLuong);

#line default
#line hidden
            EndContext();
            BeginContext(794, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 25 "C:\Code\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\InThongBao.cshtml"
        }

#line default
#line hidden
            BeginContext(835, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Models.Database.SizeSanPham>> Html { get; private set; }
    }
}
#pragma warning restore 1591