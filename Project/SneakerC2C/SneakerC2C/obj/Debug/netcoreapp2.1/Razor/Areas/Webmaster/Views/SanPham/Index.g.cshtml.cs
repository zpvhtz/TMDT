#pragma checksum "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e17147e35692b7c24ada3acf5096c3f372e77a20"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Webmaster_Views_SanPham_Index), @"mvc.1.0.view", @"/Areas/Webmaster/Views/SanPham/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Webmaster/Views/SanPham/Index.cshtml", typeof(AspNetCore.Areas_Webmaster_Views_SanPham_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e17147e35692b7c24ada3acf5096c3f372e77a20", @"/Areas/Webmaster/Views/SanPham/Index.cshtml")]
    public class Areas_Webmaster_Views_SanPham_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Models.Database.SanPham>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "SanPham", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100px; height:100px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Nam", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Nữ", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditSP", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(101, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(196, 651, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-12"">
        <h2 class=""page-header"">DANH SÁCH SẢN PHẨM</h2>
    </div>
    <!-- /.col-lg-12 -->
</div>
<div class=""panel panel-default"">
    <div class=""panel-body"">
        <!-- Search form -->
        <div class=""row"">
            <div class=""col-lg-1"">
                <button class=""btn btn-primary"" data-toggle=""modal"" data-target=""#Them"">Thêm</button>
            </div>
            <div class=""col-lg-2"">
                <div class=""form-group"">
                    <select class=""form-control"" id=""sortList"" onchange=""window.location.href = SearchAndSort()"">
                        ");
            EndContext();
            BeginContext(847, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfc65fbdb87d4df1814588b88473b9ac", async() => {
                BeginContext(873, 12, true);
                WriteLiteral("Sắp xếp theo");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(894, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(920, 26, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0aede47010240f4b41029944189800f", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(946, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(972, 26, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c25ea2b161044e282e2673b06bb0e0c", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(998, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(1024, 26, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1820a02975ef41c28a1dae3d0db8bfc4", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1050, 171, true);
            WriteLiteral("\r\n                    </select>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\"></div>\r\n            <div class=\"col-lg-3\">\r\n                ");
            EndContext();
            BeginContext(1221, 573, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a71bf9fac5c423fa1261d5a0ad11296", async() => {
                BeginContext(1285, 502, true);
                WriteLiteral(@"
                    <div class=""input-group custom-search-form"">
                        <input type=""text"" class=""form-control"" id=""searchList"" placeholder=""Tìm kiếm..."" name=""search"">
                        <span class=""input-group-btn"">
                            <button class=""btn btn-default"" type=""submit"">
                                <i class=""fa fa-search""></i>
                            </button>
                        </span>

                    </div>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1794, 748, true);
            WriteLiteral(@"
            </div>
        </div>
        <!--Table-->
        <table width=""100%"" class=""table table-striped table-bordered table-hover"" id=""dataTables-example"">
            <thead class=""thead-dark"">
                <tr class=""odd gradeX"">
                    <td>Mã sản phẩm</td>
                    <td>Tên sản phẩm</td>
                    <td>Tên shop</td>
                    <td>Màu</td>
                    <td>Hãng</td>
                    <td>Phân loại</td>
                    <td>Giá</td>
                    <td>Hình</td>
                    <td>Chi tiết</td>
                    <td>Giảm giá</td>
                    <td></td>
                </tr>
            </thead>
            <tbody class=""body-content"">
");
            EndContext();
#line 66 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(2607, 65, true);
            WriteLiteral("                    <tr>\r\n                        <td class=\"ma\">");
            EndContext();
            BeginContext(2673, 14, false);
#line 69 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                                  Write(item.MaSanPham);

#line default
#line hidden
            EndContext();
            BeginContext(2687, 49, true);
            WriteLiteral("</td>\r\n                        <td class=\"tensp\">");
            EndContext();
            BeginContext(2737, 15, false);
#line 70 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                                     Write(item.TenSanPham);

#line default
#line hidden
            EndContext();
            BeginContext(2752, 51, true);
            WriteLiteral("</td>\r\n                        <td class=\"tenshop\">");
            EndContext();
            BeginContext(2804, 33, false);
#line 71 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                                       Write(item.IdTaiKhoanNavigation.TenShop);

#line default
#line hidden
            EndContext();
            BeginContext(2837, 47, true);
            WriteLiteral("</td>\r\n                        <td class=\"mau\">");
            EndContext();
            BeginContext(2885, 8, false);
#line 72 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                                   Write(item.Mau);

#line default
#line hidden
            EndContext();
            BeginContext(2893, 63, true);
            WriteLiteral("</td>\r\n                        <td id=\"mahang\" class=\"tenhang\">");
            EndContext();
            BeginContext(2957, 36, false);
#line 73 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                                                   Write(item.IdHangSanPhamNavigation.TenHang);

#line default
#line hidden
            EndContext();
            BeginContext(2993, 52, true);
            WriteLiteral("</td>\r\n                        <td class=\"phanloai\">");
            EndContext();
            BeginContext(3046, 13, false);
#line 74 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                                        Write(item.PhanLoai);

#line default
#line hidden
            EndContext();
            BeginContext(3059, 47, true);
            WriteLiteral("</td>\r\n                        <td class=\"gia\">");
            EndContext();
            BeginContext(3107, 32, false);
#line 75 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                                   Write(item.Gia.Value.ToString("# VND"));

#line default
#line hidden
            EndContext();
            BeginContext(3139, 78, true);
            WriteLiteral("</td>\r\n                        <td class=\"hinh\">\r\n                            ");
            EndContext();
            BeginContext(3217, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7c470891a0b84fb98eceae1c1cbff2eb", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3227, "~/Hinh/SanPham/", 3227, 15, true);
#line 77 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
AddHtmlAttributeValue("", 3242, item.Hinh, 3242, 10, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3291, 77, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"chitiet\">");
            EndContext();
            BeginContext(3369, 12, false);
#line 79 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                                       Write(item.ChiTiet);

#line default
#line hidden
            EndContext();
            BeginContext(3381, 51, true);
            WriteLiteral("</td>\r\n                        <td class=\"giamgia\">");
            EndContext();
            BeginContext(3433, 12, false);
#line 80 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                                       Write(item.GiamGia);

#line default
#line hidden
            EndContext();
            BeginContext(3445, 365, true);
            WriteLiteral(@"</td>
                        <td>
                            <button class=""btn btn-danger"" type=""button"" data-toggle=""modal"" data-target=""#Suamodal"" id=""SuaSp"">Sửa</button>
                            <button class=""btn btn-danger"" type=""button"" data-toggle=""modal"" data-target=""#Khoa"">Khoá</button>
                        </td>
                    </tr>
");
            EndContext();
#line 86 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(3829, 227, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n<!-- /.panel-body -->\r\n<!--Modal them-->\r\n<div></div>\r\n<!--Modal sua-->\r\n<div class=\"modal fade\" id=\"Suamodal\" role=\"dialog\">\r\n    <div class=\"modal-dialog\">\r\n        ");
            EndContext();
            BeginContext(4056, 3512, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7689184818fb42ecbed60952ea1f05c8", async() => {
                BeginContext(4121, 1385, true);
                WriteLiteral(@"
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                    <h4 class=""modal-title"">Sản phẩm</h4>
                </div>
                <div class=""modal-body"">
                    <div class=""form-group"">
                        <label>Mã sản phẩm: </label>
                        <input type=""text"" class=""form-control"" name=""Maedit"" id=""masp-sua"" />
                    </div>
                    <div class=""form-group"">
                        <label>Tên sản phẩm: </label>
                        <input type=""text"" class=""form-control"" name=""Tenedit"" id=""tensp-sua"" />
                    </div>
                    <div class=""form-group"">
                        <label>Tên shop: </label>
                        <input type=""text"" class=""form-control"" name=""Tenshopedit"" id=""tenshop-sua"" />
                    </div>
                    <div class=""form-");
                WriteLiteral(@"group"">
                        <label>Màu: </label>
                        <input type=""text"" class=""form-control"" name=""Mauedit"" id=""mau-sua"" />
                    </div>
                    <div class=""form-group"">
                        <label>Tên hãng: </label>
                        <select class=""form-control"" id=""hang-sua"" name=""Hangedit"">
");
                EndContext();
#line 123 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                             foreach (var item in ViewBag.Hang)
                            {

#line default
#line hidden
                BeginContext(5602, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(5634, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cef4a84cf96647a3b11efcb44a585aaa", async() => {
                    BeginContext(5660, 12, false);
#line 125 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                                                    Write(item.TenHang);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 125 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                                   WriteLiteral(item.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5681, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 126 "F:\GitHub\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\SanPham\Index.cshtml"
                            }

#line default
#line hidden
                BeginContext(5714, 281, true);
                WriteLiteral(@"                        </select>
                    </div>
                    <div class=""form-group"">
                        <label>Phân loại:</label>
                        <select class=""form-control"" id=""phanloai-sua"" name=""Phanloaiedit"">
                            ");
                EndContext();
                BeginContext(5995, 32, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "120edd13b4394e0d9ce80e5b742b377e", async() => {
                    BeginContext(6015, 3, true);
                    WriteLiteral("Nam");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6027, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
                BeginContext(6057, 30, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06ac91688eaa4802bb9d2ab81a411112", async() => {
                    BeginContext(6076, 2, true);
                    WriteLiteral("Nữ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6087, 958, true);
                WriteLiteral(@"
                        </select>
                    </div>
                    <div class=""form-group"">
                        <label>Giá: </label>
                        <input type=""text"" class=""form-control"" name=""Giaedit"" id=""gia-sua"" />
                    </div>
                    <div class=""form-group"">
                        <label>Hình: </label>
                        <input type=""text"" class=""form-control"" name=""Hinhedit"" id=""hinh-sua"" />
                    </div>
                    <div class=""form-group"">
                        <label>Chi tiết: </label>
                        <input type=""text"" class=""form-control"" name=""Chitietedit"" id=""chitiet-sua"" />
                    </div>
                    <div class=""form-group"">
                        <label>Giảm giá: </label>
                        <input type=""text"" class=""form-control"" name=""Giamgiaedit"" id=""giamgia-sua"" />
                    </div>
");
                EndContext();
                BeginContext(7258, 303, true);
                WriteLiteral(@"
                </div>
                <div class=""modal-footer"">
                    <button type=""submit"" class=""btn btn-warning"">Sửa</button>
                    <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">Đóng</button>
                </div>
            </div>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7568, 1415, true);
            WriteLiteral(@"
    </div>
</div>
<script>
    $(document).ready(function () {
        $(""#SuaSp"").click(function ()
        {
            let Id = $(this).closest('tr').find('.ma').text();
            let pTen = $(this).closest('tr').find('.ten').text();
            let pTenShop = $(this).closest('tr').find('.tenshop').text();
            let pMau = $(this).closest('tr').find('.mau').text();
            var pHang = document.getElementById(""mahang"");
            //let pHang = $(this).closest('tr').find('.tenhang').val();
            let pPhanLoai = $(this).closest('tr').find('.phanloai').val();
            let pGia = $(this).closest('tr').find('.gia').text();
            let pHinh = $(this).closest('tr').find('.hinh').text();
            let pChiTiet = $(this).closest('tr').find('.chitiet').text();
            let pGiamGia = $(this).closest('tr').find('.giamgia').text();

            $(""#masp-sua"").val(Id.trim());
            $(""#ten-sua"").val(pTen.trim());
            $(""#tenshop-sua"").val(pTenShop.tri");
            WriteLiteral(@"m());
            $(""#mau-sua"").val(pMau.trim());
            $(""#hang-sua"").val(pHang.trim());
            $(""#phanloai-sua"").val(pPhanLoai.trim());
            $(""#gia-sua"").val(pGia.trim());
            $(""#hinh-sua"").val(pHinh.trim());
            $(""#chitiet-sua"").val(pChiTiet.trim());
            $(""#giamgia-sua"").val(pGiamGia.trim());
        });

    });
</script>


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
