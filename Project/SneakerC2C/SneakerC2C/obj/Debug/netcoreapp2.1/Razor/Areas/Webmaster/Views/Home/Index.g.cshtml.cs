#pragma checksum "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13af6d80efe1da948a56bdd8d091ddb54184feaf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Webmaster_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Webmaster/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Webmaster/Views/Home/Index.cshtml", typeof(AspNetCore.Areas_Webmaster_Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13af6d80efe1da948a56bdd8d091ddb54184feaf", @"/Areas/Webmaster/Views/Home/Index.cshtml")]
    public class Areas_Webmaster_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-footer text-white clearfix small z-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Webmaster", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "TaiKhoan", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "SanPham", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "DonHang_Webmaster", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "GoiQuangCao", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("align", new global::Microsoft.AspNetCore.Html.HtmlString("center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(147, 533, true);
            WriteLiteral(@"

<h1 class=""page-header"">TRANG CHỦ - THỐNG KÊ HOẠT ĐỘNG WEBSITE</h1>
<hr>


<!------------------------------------------------- 4 Icon card ------------------------------------------------->
<div class=""row"">


    <div class=""col-xl-3 col-sm-6 mb-3"">
        <div class=""card text-white bg-primary o-hidden h-100"">
            <div class=""card-body"">
                <div class=""card-body-icon"">
                    <i class=""fas fa-fw fa-comments""></i>
                </div>
                <div class=""mr-5""><b>(");
            EndContext();
            BeginContext(681, 18, false);
#line 22 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Home\Index.cshtml"
                                 Write(ViewBag.NewAccount);

#line default
#line hidden
            EndContext();
            BeginContext(699, 76, true);
            WriteLiteral(")</b> Tài Khoản Được Tạo Trong Tháng</div>\r\n            </div>\r\n            ");
            EndContext();
            BeginContext(775, 324, false);
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8f927a7ad994d34b898c4c3fc0f6bff", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f5cd16e168748afac1ac451578bb9fe", async() => {
>>>>>>> e74041296e4875fb5e35ff4346dfa89bbe31a664
                BeginContext(894, 201, true);
                WriteLiteral("\r\n                <span class=\"float-left\">Xem Chi Tiết</span>\r\n                <span class=\"float-right\">\r\n                    <i class=\"fas fa-angle-right\"></i>\r\n                </span>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
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
            BeginContext(1099, 348, true);
            WriteLiteral(@"
        </div>
    </div>

    <div class=""col-xl-3 col-sm-6 mb-3"">
        <div class=""card text-white bg-success o-hidden h-100"">
            <div class=""card-body"">
                <div class=""card-body-icon"">
                    <i class=""fas fa-fw fa-shopping-cart""></i>
                </div>
                <div class=""mr-5""><b>(");
            EndContext();
            BeginContext(1448, 18, false);
#line 39 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Home\Index.cshtml"
                                 Write(ViewBag.NewProduct);

#line default
#line hidden
            EndContext();
            BeginContext(1466, 77, true);
            WriteLiteral(")</b> Sản Phẩm Được Tạo Trong Tháng</div>\r\n            </div>\r\n\r\n            ");
            EndContext();
            BeginContext(1543, 323, false);
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "722b3fa3a7ca4e259e9691ed223ed0f7", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8548852a92604a418748c7e08b271dab", async() => {
>>>>>>> e74041296e4875fb5e35ff4346dfa89bbe31a664
                BeginContext(1661, 201, true);
                WriteLiteral("\r\n                <span class=\"float-left\">Xem Chi Tiết</span>\r\n                <span class=\"float-right\">\r\n                    <i class=\"fas fa-angle-right\"></i>\r\n                </span>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
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
            BeginContext(1866, 345, true);
            WriteLiteral(@"
        </div>
    </div>


    <div class=""col-xl-3 col-sm-6 mb-3"">
        <div class=""card text-white bg-danger o-hidden h-100"">
            <div class=""card-body"">
                <div class=""card-body-icon"">
                    <i class=""fas fa-fw fa-life-ring""></i>
                </div>
                <div class=""mr-5""><b>(");
            EndContext();
            BeginContext(2212, 14, false);
#line 58 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Home\Index.cshtml"
                                 Write(ViewBag.NewBil);

#line default
#line hidden
            EndContext();
            BeginContext(2226, 70, true);
            WriteLiteral(")</b> Đơn Hàng Chưa Thanh Toán</div>\r\n            </div>\r\n            ");
            EndContext();
            BeginContext(2296, 333, false);
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff3d2f905c564594a3d7e57a2906f08b", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9c1f833c0394c27bd4c49909073245a", async() => {
>>>>>>> e74041296e4875fb5e35ff4346dfa89bbe31a664
                BeginContext(2424, 201, true);
                WriteLiteral("\r\n                <span class=\"float-left\">View Details</span>\r\n                <span class=\"float-right\">\r\n                    <i class=\"fas fa-angle-right\"></i>\r\n                </span>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
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
            BeginContext(2629, 339, true);
            WriteLiteral(@"
        </div>
    </div>

    <div class=""col-xl-3 col-sm-6 mb-3"">
        <div class=""card text-white bg-warning o-hidden h-100"">
            <div class=""card-body"">
                <div class=""card-body-icon"">
                    <i class=""fas fa-fw fa-list""></i>
                </div>
                <div class=""mr-5""><b>(");
            EndContext();
            BeginContext(2969, 16, false);
#line 75 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Home\Index.cshtml"
                                 Write(ViewBag.QuangCao);

#line default
#line hidden
            EndContext();
            BeginContext(2985, 69, true);
            WriteLiteral(")</b> Gói Quảng Cáo Hiện Hành</div>\r\n            </div>\r\n            ");
            EndContext();
            BeginContext(3054, 327, false);
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "852f44938b0f43f79a97d777ca848360", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab6a38829036411c9dd0cd1fca784f5b", async() => {
>>>>>>> e74041296e4875fb5e35ff4346dfa89bbe31a664
                BeginContext(3176, 201, true);
                WriteLiteral("\r\n                <span class=\"float-left\">Xem Chi Tiết</span>\r\n                <span class=\"float-right\">\r\n                    <i class=\"fas fa-angle-right\"></i>\r\n                </span>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
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
            BeginContext(3381, 220, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<!------------------------------------------------- Search Area ------------------------------------------------->\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-lg-12\">      \r\n        ");
            EndContext();
            BeginContext(3601, 569, false);
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac56e76ff1e142179a0af6210e4e3a05", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccfc522ca122479c85359924093e3389", async() => {
>>>>>>> e74041296e4875fb5e35ff4346dfa89bbe31a664
                BeginContext(3622, 541, true);
                WriteLiteral(@"
            <div class=""input-group custom-search-form"">
                <input type=""month"" id=""nbd"" name=""nbd"" class=""form-control"" value=""2018-01"" size=""100"">
                <input type=""month"" id=""nkt"" name=""nkt"" class=""form-control"" value=""2018-12"" size=""100"">
                <span class=""input-group-btn"">
                    <button class=""btn btn-primary"" type=""button"" id=""btnSearch"">
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4170, 2484, true);
            WriteLiteral(@"
    </div>
</div>

<!------------------------------------------------- Chart Area ------------------------------------------------->
<div id=""wrapper"">
    <div id=""content-wrapper"">
        <div class=""container-fluid"">


            <!-- 2 Chart Example-->
            <div class=""row"">
                <div class=""col-lg-8"">

                    <div class=""card mb-3"">
                        <div class=""card-header"">
                            <i class=""fas fa-chart-bar""></i>
                            Thống Kê Doanh Thu Merchant:
                        </div>
                        <div class=""card-body"">
                            <canvas id=""myBarChart"" width=""100%"" height=""50""></canvas>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""card mb-3"">
                        <div class=""card-header"">
                            <i class=""fas fa-chart-pie""></i>
             ");
            WriteLiteral(@"               Thống Kê Số Lượng Người Dùng
                        </div>
                        <div class=""card-body"">
                            <canvas id=""myPieChart"" width=""100%"" height=""100""></canvas>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Area Chart Example-->
            <div class=""card mb-3"">
                <div class=""card-header"">
                    <i class=""fas fa-chart-area""></i>
                    Thống Kê Doanh Thu Quảng Cáo:
                </div>
                <div class=""card-body"">
                    <canvas id=""myAreaChart"" width=""100%"" height=""30""></canvas>
                </div>
            </div>
            <div class=""card mb-3"">
                <div class=""card-header"">
                    <i class=""fas fa-chart-area""></i>
                    Thống Kê Doanh Thu Gian Hàng:
                </div>
                <div class=""card-body"">
                    <canvas id=""myArea");
            WriteLiteral(@"Chart1"" width=""100%"" height=""30""></canvas>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    $(""#btnSearch"").click(function () {
        let nbd = $(""#nbd"").val();
        let nkt = $(""#nkt"").val();
        LoadDuLieuArea(nbd, nkt);
        LoadDuLieuArea1(nbd, nkt);
        LoadDuLieuBar(nbd, nkt);
        //LoadDuLieuPie(nbd);
        LoadDuLieuPie()
    });


</script>

");
            EndContext();
#line 174 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Home\Index.cshtml"
 if (ViewBag.ThongBao != null)
{

#line default
#line hidden
            BeginContext(6689, 29, true);
            WriteLiteral("    <script>\r\n        alert(\"");
            EndContext();
            BeginContext(6719, 26, false);
#line 177 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Home\Index.cshtml"
          Write(Html.Raw(ViewBag.ThongBao));

#line default
#line hidden
            EndContext();
            BeginContext(6745, 20, true);
            WriteLiteral("\");\r\n    </script>\r\n");
            EndContext();
#line 179 "D:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Webmaster\Views\Home\Index.cshtml"
}

#line default
#line hidden
            BeginContext(6768, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
