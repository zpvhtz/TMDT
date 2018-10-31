#pragma checksum "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68a38b1e4bf697a79a7db5b742efa3a38faea410"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Webmaster_Views_LoaiNguoiDung_Index), @"mvc.1.0.view", @"/Areas/Webmaster/Views/LoaiNguoiDung/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Webmaster/Views/LoaiNguoiDung/Index.cshtml", typeof(AspNetCore.Areas_Webmaster_Views_LoaiNguoiDung_Index))]
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
#line 2 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Index.cshtml"
using PagedList.Mvc;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68a38b1e4bf697a79a7db5b742efa3a38faea410", @"/Areas/Webmaster/Views/LoaiNguoiDung/Index.cshtml")]
    public class Areas_Webmaster_Views_LoaiNguoiDung_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList.IPagedList<Models.Database.LoaiNguoiDung>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(176, 597, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-12"">
        <h1 class=""page-header"">Danh Sách Loại Người Dùng</h1>
    </div>
    <!-- /.col-lg-12 -->
</div>
<div class=""col-lg-12"">
    <div class=""panel panel-default"">
        <!-- /.panel-heading -->
        <div class=""panel-body"">
            <div class=""table-responsive"">
                <table class=""table table-striped table-bordered table-hover"">
                    <!--------------------------------------------- Search And Add ------------------------------------------------->
                    <div class=""form-group"">
");
            EndContext();
            BeginContext(1145, 800, true);
            WriteLiteral(@"                        <a href=""/LoaiNguoiDung""><button type=""submit"" class=""btn btn-primary"">Làm Mới</button></a>
                        <a href=""/DaiLy/Create""><button type=""button"" class=""btn btn-warning"">Thêm Mới</button></a>
                    </div>
                    <!------------------------------------------- Loading Edit Delete ----------------------------------------------->
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Mã Loại người Dùng</th>
                            <th>Tên Loại người Dùng</th>
                            <th>Tình Trạng</th>
                            <th>Chức Năng</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 42 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(2026, 27, true);
            WriteLiteral("                        <tr");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2053, "\"", 2067, 2);
            WriteAttributeValue("", 2058, "row_", 2058, 4, true);
#line 44 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Index.cshtml"
WriteAttributeValue("", 2062, item, 2062, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2068, 36, true);
            WriteLiteral(">\r\n                            <td> ");
            EndContext();
            BeginContext(2105, 7, false);
#line 45 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Index.cshtml"
                            Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(2112, 40, true);
            WriteLiteral("</td>\r\n                            <td> ");
            EndContext();
            BeginContext(2153, 20, false);
#line 46 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Index.cshtml"
                            Write(item.MaLoaiNguoiDung);

#line default
#line hidden
            EndContext();
            BeginContext(2173, 40, true);
            WriteLiteral("</td>\r\n                            <td> ");
            EndContext();
            BeginContext(2214, 21, false);
#line 47 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Index.cshtml"
                            Write(item.TenLoaiNguoiDung);

#line default
#line hidden
            EndContext();
            BeginContext(2235, 40, true);
            WriteLiteral("</td>\r\n                            <td> ");
            EndContext();
            BeginContext(2276, 14, false);
#line 48 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Index.cshtml"
                            Write(item.TinhTrang);

#line default
#line hidden
            EndContext();
            BeginContext(2290, 75, true);
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2365, "\"", 2405, 2);
            WriteAttributeValue("", 2372, "/DaiLy/Edit/", 2372, 12, true);
#line 50 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Index.cshtml"
WriteAttributeValue("", 2384, item.MaLoaiNguoiDung, 2384, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2406, 145, true);
            WriteLiteral("><button type=\"button\" class=\"btn btn-primary\">Sửa</button></a>\r\n                                <button type=\"button\" class=\"btn btn-warning\">\r\n");
            EndContext();
            BeginContext(3052, 115, true);
            WriteLiteral("\r\n\r\n\r\n                                </button>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 76 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(3194, 148, true);
            WriteLiteral("                    </tbody>\r\n                </table>                                                                                            \r\n");
            EndContext();
            BeginContext(3434, 148, true);
            WriteLiteral("            </div>\r\n            <!-- /.table-responsive -->\r\n        </div>\r\n        <!-- /.panel-body -->\r\n    </div>\r\n    <!-- /.panel -->\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList.IPagedList<Models.Database.LoaiNguoiDung>> Html { get; private set; }
    }
}
#pragma warning restore 1591
