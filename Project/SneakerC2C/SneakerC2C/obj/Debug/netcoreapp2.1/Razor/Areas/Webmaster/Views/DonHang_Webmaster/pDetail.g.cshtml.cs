#pragma checksum "C:\Users\ThoXu\Desktop\C2CSNEAKERS\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\DonHang_Webmaster\pDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "739f8d32254b09c46eef4780065d7167a8ddb6ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Webmaster_Views_DonHang_Webmaster_pDetail), @"mvc.1.0.view", @"/Areas/Webmaster/Views/DonHang_Webmaster/pDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Webmaster/Views/DonHang_Webmaster/pDetail.cshtml", typeof(AspNetCore.Areas_Webmaster_Views_DonHang_Webmaster_pDetail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"739f8d32254b09c46eef4780065d7167a8ddb6ad", @"/Areas/Webmaster/Views/DonHang_Webmaster/pDetail.cshtml")]
    public class Areas_Webmaster_Views_DonHang_Webmaster_pDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Models.Database.ChiTietDonHang>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 400, true);
            WriteLiteral(@"
<table width=""100%"" class=""table table-striped table-bordered table-hover"" id=""dataTables-example"">
    <thead class=""thead-dark"">
        <tr>
            <th>Mã Đơn Hàng</th>
            <th>Tên Sản Phẩm</th>
            <th>Tên Shop</th>
            <th>Size</th>
            <th>Số Lượng</th>
            <th>Đơn Giá</th>
        </tr>
    </thead>
    <tbody class=""body-content"">
");
            EndContext();
#line 15 "C:\Users\ThoXu\Desktop\C2CSNEAKERS\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\DonHang_Webmaster\pDetail.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(501, 80, true);
            WriteLiteral("            <tr class=\"odd gradeX\">\r\n                <td class=\"item-madonhang\">");
            EndContext();
            BeginContext(582, 34, false);
#line 18 "C:\Users\ThoXu\Desktop\C2CSNEAKERS\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\DonHang_Webmaster\pDetail.cshtml"
                                      Write(item.IdDonHangNavigation.MaDonHang);

#line default
#line hidden
            EndContext();
            BeginContext(616, 54, true);
            WriteLiteral("</td>\r\n                <td class=\"item-cmndnguoigiao\">");
            EndContext();
            BeginContext(671, 59, false);
#line 19 "C:\Users\ThoXu\Desktop\C2CSNEAKERS\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\DonHang_Webmaster\pDetail.cshtml"
                                          Write(item.IdSizeSanPhamNavigation.IdSanPhamNavigation.TenSanPham);

#line default
#line hidden
            EndContext();
            BeginContext(730, 51, true);
            WriteLiteral("</td>\r\n                <td class=\"item-diachigiao\">");
            EndContext();
            BeginContext(782, 77, false);
#line 20 "C:\Users\ThoXu\Desktop\C2CSNEAKERS\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\DonHang_Webmaster\pDetail.cshtml"
                                       Write(item.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenShop);

#line default
#line hidden
            EndContext();
            BeginContext(859, 48, true);
            WriteLiteral("</td>\r\n                <td class=\"item-ngaytao\">");
            EndContext();
            BeginContext(908, 33, false);
#line 21 "C:\Users\ThoXu\Desktop\C2CSNEAKERS\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\DonHang_Webmaster\pDetail.cshtml"
                                    Write(item.IdSizeSanPhamNavigation.Size);

#line default
#line hidden
            EndContext();
            BeginContext(941, 49, true);
            WriteLiteral("</td>\r\n                <td class=\"item-ngaygiao\">");
            EndContext();
            BeginContext(991, 12, false);
#line 22 "C:\Users\ThoXu\Desktop\C2CSNEAKERS\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\DonHang_Webmaster\pDetail.cshtml"
                                     Write(item.SoLuong);

#line default
#line hidden
            EndContext();
            BeginContext(1003, 49, true);
            WriteLiteral("</td>\r\n                <td class=\"item-tongtien\">");
            EndContext();
            BeginContext(1053, 11, false);
#line 23 "C:\Users\ThoXu\Desktop\C2CSNEAKERS\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\DonHang_Webmaster\pDetail.cshtml"
                                     Write(item.DonGia);

#line default
#line hidden
            EndContext();
            BeginContext(1064, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 25 "C:\Users\ThoXu\Desktop\C2CSNEAKERS\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\DonHang_Webmaster\pDetail.cshtml"
        }

#line default
#line hidden
            BeginContext(1101, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
