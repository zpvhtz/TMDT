#pragma checksum "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f044cc748907ade99c81494e11584e45c7d0df90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Webmaster_Views_LoaiNguoiDung_Create), @"mvc.1.0.view", @"/Areas/Webmaster/Views/LoaiNguoiDung/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Webmaster/Views/LoaiNguoiDung/Create.cshtml", typeof(AspNetCore.Areas_Webmaster_Views_LoaiNguoiDung_Create))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f044cc748907ade99c81494e11584e45c7d0df90", @"/Areas/Webmaster/Views/LoaiNguoiDung/Create.cshtml")]
    public class Areas_Webmaster_Views_LoaiNguoiDung_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.Database.LoaiNguoiDung>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(134, 396, true);
            WriteLiteral(@"
<h2>Thêm Mới Loại Người Dùng</h2>



                        <hr />
<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""panel panel-default"">
            <div class=""panel-heading"">
                Nhập Thông Tin Loại Người Dùng:
            </div>

            <div class=""panel-body"">
                <div class=""row"">
                    <div class=""col-lg-12"">
");
            EndContext();
#line 23 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"
                         using (Html.BeginForm("Create", "LoaiNguoiDung", FormMethod.Post))
                        {
                            

#line default
#line hidden
            BeginContext(679, 23, false);
#line 25 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"
                       Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(735, 64, false);
#line 27 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"
                       Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(805, 86, true);
            WriteLiteral("                            <div class=\"form-group\">\r\n                                ");
            EndContext();
            BeginContext(892, 104, false);
#line 31 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"
                           Write(Html.LabelFor(model => model.MaLoaiNguoiDung, htmlAttributes: new { @class = "control-label col-md-3" }));

#line default
#line hidden
            EndContext();
            BeginContext(996, 36, true);
            WriteLiteral("\r\n\r\n                                ");
            EndContext();
            BeginContext(1033, 105, false);
#line 33 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"
                           Write(Html.TextBoxFor(model => model.MaLoaiNguoiDung, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1138, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(1173, 93, false);
#line 34 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"
                           Write(Html.ValidationMessageFor(model => model.MaLoaiNguoiDung, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1266, 40, true);
            WriteLiteral("\r\n\r\n                            </div>\r\n");
            EndContext();
            BeginContext(1308, 86, true);
            WriteLiteral("                            <div class=\"form-group\">\r\n                                ");
            EndContext();
            BeginContext(1395, 105, false);
#line 39 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"
                           Write(Html.LabelFor(model => model.TenLoaiNguoiDung, htmlAttributes: new { @class = "control-label col-md-3" }));

#line default
#line hidden
            EndContext();
            BeginContext(1500, 36, true);
            WriteLiteral("\r\n\r\n                                ");
            EndContext();
            BeginContext(1537, 106, false);
#line 41 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"
                           Write(Html.TextBoxFor(model => model.TenLoaiNguoiDung, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1643, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(1678, 94, false);
#line 42 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"
                           Write(Html.ValidationMessageFor(model => model.TenLoaiNguoiDung, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1772, 40, true);
            WriteLiteral("\r\n\r\n                            </div>\r\n");
            EndContext();
            BeginContext(1814, 305, true);
            WriteLiteral(@"                            <div class=""form-group"">
                                <div class=""col-md-offset-2 col-md-10"">
                                    <input type=""submit"" value=""Thêm Mới"" class=""btn btn-default"" />
                                </div>
                            </div>
");
            EndContext();
#line 51 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"

                        }

#line default
#line hidden
            BeginContext(2148, 167, true);
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n                        <div>\r\n                            ");
            EndContext();
            BeginContext(2316, 45, false);
#line 60 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\LoaiNguoiDung\Create.cshtml"
                       Write(Html.ActionLink("Quay Về Danh Sách", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(2361, 36, true);
            WriteLiteral("\r\n                        </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.Database.LoaiNguoiDung> Html { get; private set; }
    }
}
#pragma warning restore 1591
