#pragma checksum "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\TaiKhoan\DiaChiPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4e75d229f869011bd9c8cdfddb4dc1c4e73cb11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Webmaster_Views_TaiKhoan_DiaChiPartialView), @"mvc.1.0.view", @"/Areas/Webmaster/Views/TaiKhoan/DiaChiPartialView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Webmaster/Views/TaiKhoan/DiaChiPartialView.cshtml", typeof(AspNetCore.Areas_Webmaster_Views_TaiKhoan_DiaChiPartialView))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4e75d229f869011bd9c8cdfddb4dc1c4e73cb11", @"/Areas/Webmaster/Views/TaiKhoan/DiaChiPartialView.cshtml")]
    public class Areas_Webmaster_Views_TaiKhoan_DiaChiPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Models.Database.DiaChi>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 148, true);
            WriteLiteral("\r\n<div class=\"form-group\">\r\n    <label>Tên đăng nhập</label>\r\n    <input type=\"text\" class=\"form-control\" id=\"diachi-tendangnhap\" name=\"tendangnhap\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 192, "\"", 220, 1);
#line 5 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\TaiKhoan\DiaChiPartialView.cshtml"
WriteAttributeValue("", 200, ViewBag.TenDangNhap, 200, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(221, 157, true);
            WriteLiteral(" readonly>\r\n</div>\r\n\r\n<table width=\"100%\" class=\"table table-striped table-bordered table-hover\" id=\"dataTables-example\">\r\n    <tbody class=\"body-content\">\r\n");
            EndContext();
#line 10 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\TaiKhoan\DiaChiPartialView.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(427, 69, true);
            WriteLiteral("        <tr class=\"odd gradeX\">\r\n            <td class=\"item-diachi\">");
            EndContext();
            BeginContext(497, 10, false);
#line 13 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\TaiKhoan\DiaChiPartialView.cshtml"
                               Write(item.Duong);

#line default
#line hidden
            EndContext();
            BeginContext(507, 46, true);
            WriteLiteral("</td>\r\n            <td class=\"item-tinhthanh\">");
            EndContext();
            BeginContext(554, 39, false);
#line 14 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\TaiKhoan\DiaChiPartialView.cshtml"
                                  Write(item.IdTinhThanhNavigation.TenTinhThanh);

#line default
#line hidden
            EndContext();
            BeginContext(593, 295, true);
            WriteLiteral(@"</td>
            <td>
                <button class=""btn btn-primary btnSuaDiaChi"" type=""button"" data-toggle=""modal"" data-target=""#suadiachiModal"">Sửa</button>
                <button class=""btn btn-danger"" type=""button"" data-dismiss=""modal"">Đóng</button>
            </td>
        </tr>
");
            EndContext();
#line 20 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\TaiKhoan\DiaChiPartialView.cshtml"
        }

#line default
#line hidden
            BeginContext(899, 361, true);
            WriteLiteral(@"    </tbody>
</table>

<div id=""collapseThemDiaChi"" class=""collapse"">
    <div class=""form-group"">
        <label>Địa chỉ</label>
        <input type=""text"" class=""form-control"" name=""diachi"" required>
    </div>
    <div class=""form-group"">
        <label>Tỉnh thành</label>
        <select class=""form-control"" id=""listTinhThanh"" name=""tinhthanh"">
");
            EndContext();
#line 32 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\TaiKhoan\DiaChiPartialView.cshtml"
             foreach (var item in ViewBag.TinhThanh)
            {

#line default
#line hidden
            BeginContext(1329, 23, true);
            WriteLiteral("                <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1352, "\"", 1368, 1);
#line 34 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\TaiKhoan\DiaChiPartialView.cshtml"
WriteAttributeValue("", 1360, item.Id, 1360, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1369, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1371, 17, false);
#line 34 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\TaiKhoan\DiaChiPartialView.cshtml"
                                    Write(item.TenTinhThanh);

#line default
#line hidden
            EndContext();
            BeginContext(1388, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 35 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\TaiKhoan\DiaChiPartialView.cshtml"
            }

#line default
#line hidden
            BeginContext(1414, 638, true);
            WriteLiteral(@"        </select>
    </div>
</div>

<script>
    $("".btnSuaDiaChi"").click(function () {
        let tendangnhap = $(""#diachi-tendangnhap"").val();
        let diachi = $(this).closest('tr').find('.item-diachi').text();

        $.ajax({
            url: ""/Webmaster/TaiKhoan/GetThongTinDiaChi"",
            type: ""get"",
            data: { ""tendangnhap"": tendangnhap, ""diachi"": diachi },
            success: function (data) {
                $(""#suadiachiModal-body"").html(data);
            },
            error: function (data) {
                alert(""Error: "" + data);
            }
        });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Models.Database.DiaChi>> Html { get; private set; }
    }
}
#pragma warning restore 1591
