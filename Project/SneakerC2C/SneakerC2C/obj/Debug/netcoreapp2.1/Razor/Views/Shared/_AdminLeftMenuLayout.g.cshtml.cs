#pragma checksum "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Views\Shared\_AdminLeftMenuLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b940fcb0c94066cf5a4e338da935dc7e922e7433"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AdminLeftMenuLayout), @"mvc.1.0.view", @"/Views/Shared/_AdminLeftMenuLayout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_AdminLeftMenuLayout.cshtml", typeof(AspNetCore.Views_Shared__AdminLeftMenuLayout))]
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
#line 1 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Views\_ViewImports.cshtml"
using SneakerC2C;

#line default
#line hidden
#line 2 "D:\Projects\TMDT\Project\SneakerC2C\SneakerC2C\Views\_ViewImports.cshtml"
using SneakerC2C.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b940fcb0c94066cf5a4e338da935dc7e922e7433", @"/Views/Shared/_AdminLeftMenuLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fba3c8caa4701f14d239ab9ed73d3368c5b06145", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AdminLeftMenuLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admintemplate/vendor/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admintemplate/vendor/bootstrap/js/bootstrap.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admintemplate/vendor/metisMenu/metisMenu.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admintemplate/dist/js/sb-admin-2.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2634, true);
            WriteLiteral(@"<li>
    <a href=""index.html""><i class=""fa fa-dashboard fa-fw""></i> Dashboard</a>
</li>
<li>
    <a href=""#""><i class=""fa fa-bar-chart-o fa-fw""></i> Charts<span class=""fa arrow""></span></a>
    <ul class=""nav nav-second-level"">
        <li>
            <a href=""flot.html"">Flot Charts</a>
        </li>
        <li>
            <a href=""morris.html"">Morris.js Charts</a>
        </li>
    </ul>
    <!-- /.nav-second-level -->
</li>
<li>
    <a href=""tables.html""><i class=""fa fa-table fa-fw""></i> Tables</a>
</li>
<li>
    <a href=""forms.html""><i class=""fa fa-edit fa-fw""></i> Forms</a>
</li>
<li>
    <a href=""#""><i class=""fa fa-wrench fa-fw""></i> UI Elements<span class=""fa arrow""></span></a>
    <ul class=""nav nav-second-level"">
        <li>
            <a href=""panels-wells.html"">Panels and Wells</a>
        </li>
        <li>
            <a href=""buttons.html"">Buttons</a>
        </li>
        <li>
            <a href=""notifications.html"">Notifications</a>
        </li>
        <");
            WriteLiteral(@"li>
            <a href=""typography.html"">Typography</a>
        </li>
        <li>
            <a href=""icons.html""> Icons</a>
        </li>
        <li>
            <a href=""grid.html"">Grid</a>
        </li>
    </ul>
    <!-- /.nav-second-level -->
</li>
<li>
    <a href=""#""><i class=""fa fa-sitemap fa-fw""></i> Multi-Level Dropdown<span class=""fa arrow""></span></a>
    <ul class=""nav nav-second-level"">
        <li>
            <a href=""#"">Second Level Item</a>
        </li>
        <li>
            <a href=""#"">Second Level Item</a>
        </li>
        <li>
            <a href=""#"">Third Level <span class=""fa arrow""></span></a>
            <ul class=""nav nav-third-level"">
                <li>
                    <a href=""#"">Third Level Item</a>
                </li>
                <li>
                    <a href=""#"">Third Level Item</a>
                </li>
                <li>
                    <a href=""#"">Third Level Item</a>
                </li>
                <li>");
            WriteLiteral(@"
                    <a href=""#"">Third Level Item</a>
                </li>
            </ul>
            <!-- /.nav-third-level -->
        </li>
    </ul>
    <!-- /.nav-second-level -->
</li>
<li class=""active"">
    <a href=""#""><i class=""fa fa-files-o fa-fw""></i> Sample Pages<span class=""fa arrow""></span></a>
    <ul class=""nav nav-second-level"">
        <li>
            <a class=""active"" href=""blank.html"">Blank Page</a>
        </li>
        <li>
            <a href=""login.html"">Login Page</a>
        </li>
    </ul>
    <!-- /.nav-second-level -->
</li>
");
            EndContext();
            BeginContext(2634, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee72c04d642a4c0c8b3adf69bce16ad3", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2701, 38, true);
            WriteLiteral("\r\n<!-- Bootstrap Core JavaScript -->\r\n");
            EndContext();
            BeginContext(2739, 76, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75120f65a223427a968119f89f24dc00", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2815, 41, true);
            WriteLiteral("\r\n<!-- Metis Menu Plugin JavaScript -->\r\n");
            EndContext();
            BeginContext(2856, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93e31d55a56347c0b6bc4f36c732c83d", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2929, 36, true);
            WriteLiteral("\r\n<!-- Custom Theme JavaScript -->\r\n");
            EndContext();
            BeginContext(2965, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b4a6bf3a6d21433098288b24d584e50b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
