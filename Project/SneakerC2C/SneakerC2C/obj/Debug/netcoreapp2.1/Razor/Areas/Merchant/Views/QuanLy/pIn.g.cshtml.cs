#pragma checksum "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\pIn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4b91f68a00b66d2eee78b5714ccf5bd5837bfa3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Merchant_Views_QuanLy_pIn), @"mvc.1.0.view", @"/Areas/Merchant/Views/QuanLy/pIn.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Merchant/Views/QuanLy/pIn.cshtml", typeof(AspNetCore.Areas_Merchant_Views_QuanLy_pIn))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4b91f68a00b66d2eee78b5714ccf5bd5837bfa3", @"/Areas/Merchant/Views/QuanLy/pIn.cshtml")]
    public class Areas_Merchant_Views_QuanLy_pIn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Models.Database.SizeSanPham>>
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
#line 18 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\pIn.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(627, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(666, 35, false);
#line 21 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\pIn.cshtml"
               Write(item.IdSanPhamNavigation.TenSanPham);

#line default
#line hidden
            EndContext();
            BeginContext(701, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(729, 9, false);
#line 22 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\pIn.cshtml"
               Write(item.Size);

#line default
#line hidden
            EndContext();
            BeginContext(738, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(766, 12, false);
#line 23 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\pIn.cshtml"
               Write(item.SoLuong);

#line default
#line hidden
            EndContext();
            BeginContext(778, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 25 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Merchant\Views\QuanLy\pIn.cshtml"
        }

#line default
#line hidden
            BeginContext(815, 24, true);
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
