#pragma checksum "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52135835d7f6027f0cd2778dfddaed6f885a66bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_SanPham_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/SanPham/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Customer/Views/SanPham/Index.cshtml", typeof(AspNetCore.Areas_Customer_Views_SanPham_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52135835d7f6027f0cd2778dfddaed6f885a66bf", @"/Areas/Customer/Views/SanPham/Index.cshtml")]
    public class Areas_Customer_Views_SanPham_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.Database.SanPham>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-imagezoom", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(32, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_MainLayout.cshtml";

#line default
#line hidden
            BeginContext(126, 892, true);
            WriteLiteral(@"
<!--/single_page-->
<!-- /banner_bottom_agile_info -->
<div class=""page-head_agile_info_w3l"">
    <div class=""container"">
        <h3>Single <span>Page </span></h3>
        <!--/w3_short-->
        <div class=""services-breadcrumb"">
            <div class=""agile_inner_breadcrumb"">

                <ul class=""w3_short"">
                    <li><a href=""index.html"">Trang Chủ</a><i>|</i></li>
                    <li>Chi Tiết</li>
                </ul>
            </div>
        </div>
        <!--//w3_short-->
    </div>
</div>

<!-- banner-bootom-w3-agileits -->
<div class=""banner-bootom-w3-agileits"">
    <div class=""container"">
        <div class=""col-md-4 single-right-left "">
            <div class=""grid images_3_of_2"">
                <div class=""flexslider"">
                    <ul class=""slides"">
                        <li data-thumb=""/Hinh/SanPham/");
            EndContext();
            BeginContext(1019, 10, false);
#line 34 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                                                 Write(Model.Hinh);

#line default
#line hidden
            EndContext();
            BeginContext(1029, 58, true);
            WriteLiteral("\">\r\n                            <div class=\"thumb-image\"> ");
            EndContext();
            BeginContext(1087, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "844d4ea1a2de41a9a3a33fce10bc4eaa", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1097, "~/Hinh/SanPham/", 1097, 15, true);
#line 35 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
AddHtmlAttributeValue("", 1112, Model.Hinh, 1112, 11, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1170, 40, true);
            WriteLiteral(" </div>\r\n                        </li>\r\n");
            EndContext();
            BeginContext(1706, 224, true);
            WriteLiteral("                    </ul>\r\n                    <div class=\"clearfix\"></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-8 single-right-left simpleCart_shelfItem\">\r\n            <h3>");
            EndContext();
            BeginContext(1931, 16, false);
#line 49 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
           Write(Model.TenSanPham);

#line default
#line hidden
            EndContext();
            BeginContext(1947, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
#line 50 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
             if (Model.GiamGia != null && Model.GiamGia != 0)
            {
                double gia = Model.Gia * (100 - Model.GiamGia) / 100 ?? 0;

#line default
#line hidden
            BeginContext(2108, 44, true);
            WriteLiteral("                <p><span class=\"item_price\">");
            EndContext();
            BeginContext(2153, 21, false);
#line 53 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                                       Write(gia.ToString("#,###"));

#line default
#line hidden
            EndContext();
            BeginContext(2174, 17, true);
            WriteLiteral(" đ</span> <del>- ");
            EndContext();
            BeginContext(2192, 33, false);
#line 53 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                                                                              Write(Model.Gia.Value.ToString("#,###"));

#line default
#line hidden
            EndContext();
            BeginContext(2225, 14, true);
            WriteLiteral(" đ</del></p>\r\n");
            EndContext();
#line 54 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(2287, 44, true);
            WriteLiteral("                <p><span class=\"item_price\">");
            EndContext();
            BeginContext(2332, 33, false);
#line 57 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                                       Write(Model.Gia.Value.ToString("#,###"));

#line default
#line hidden
            EndContext();
            BeginContext(2365, 15, true);
            WriteLiteral(" đ</span></p>\r\n");
            EndContext();
#line 58 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(2395, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(3134, 470, true);
            WriteLiteral(@"
            <!--<div class=""description"">
        <h5>Check delivery, payment options and charges at your location</h5>
         <form action=""#"" method=""post"">
        <input type=""text"" value=""Enter pincode"" onfocus=""this.value = '';"" onblur=""if (this.value == '') {this.value = 'Enter pincode';}"" required="""">
        <input type=""submit"" value=""Check"">
        </form>
    </div>-->
            <div class=""brands-color"">
                <h5>Thương hiệu : ");
            EndContext();
            BeginContext(3605, 37, false);
#line 81 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                             Write(Model.IdHangSanPhamNavigation.TenHang);

#line default
#line hidden
            EndContext();
            BeginContext(3642, 93, true);
            WriteLiteral("</h5>\r\n            </div>\r\n            <div class=\"brands-color\">\r\n                <h5>Màu : ");
            EndContext();
            BeginContext(3736, 9, false);
#line 84 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                     Write(Model.Mau);

#line default
#line hidden
            EndContext();
            BeginContext(3745, 107, true);
            WriteLiteral("</h5>\r\n            </div>\r\n            <div class=\"brands-color\">\r\n                <h5>Ngày đăng sản phẩm: ");
            EndContext();
            BeginContext(3853, 14, false);
#line 87 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                                   Write(Model.NgayDang);

#line default
#line hidden
            EndContext();
            BeginContext(3867, 241, true);
            WriteLiteral("</h5>\r\n            </div>\r\n            <div class=\"brands-color\">\r\n                <h5 class=\"tieude_h5_single\">Size :</h5>\r\n                <select id=\"sltSizeSanPham\" onchange=\"change_country(this.value)\" class=\"frm-field required sect\">\r\n");
            EndContext();
#line 92 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                     foreach (var item in ViewBag.ListSizeSanPham)
                    {

#line default
#line hidden
            BeginContext(4199, 31, true);
            WriteLiteral("                        <option");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4230, "\"", 4246, 1);
#line 94 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
WriteAttributeValue("", 4238, item.Id, 4238, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4247, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(4249, 9, false);
#line 94 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                                            Write(item.Size);

#line default
#line hidden
            EndContext();
            BeginContext(4258, 11, true);
            WriteLiteral("</option>\r\n");
            EndContext();
#line 95 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(4292, 2346, true);
            WriteLiteral(@"                </select>
            </div>
            <div class=""brands-color"">
                <h5 class=""tieude_h5_single"">Số lượng :</h5>
                <div class=""tang_soluong"">
                    <button class=""button_tanggiam_sl"">
                        <i class=""fa fa-plus""></i>
                    </button>
                    <input class=""soluong"" type=""text"" value=""1"">
                    <button class=""button_tanggiam_sl"">
                        <i class=""fa fa-minus""></i>
                    </button>
                </div>
            </div>
            <!--<div class=""occasional"">
        <h5>Types :</h5>
        <div class=""colr ert"">
            <label class=""radio""><input type=""radio"" name=""radio"" checked=""""><i></i>Casual Shoes</label>
        </div>
        <div class=""colr"">
            <label class=""radio""><input type=""radio"" name=""radio""><i></i>Sneakers </label>
        </div>
        <div class=""colr"">
            <label class=""radio""><input type=""radio"" ");
            WriteLiteral(@"name=""radio""><i></i>Formal Shoes</label>
        </div>
        <div class=""clearfix""> </div>
    </div>-->
            <div class=""occasion-cart"">
                <div class=""snipcart-details top_brand_home_details item_add single-item hvr-outline-out button2"">
                    <form action=""#"" method=""post"">
                        <fieldset>
                            <input type=""hidden"" name=""cmd"" value=""_cart"">
                            <input type=""hidden"" name=""add"" value=""1"">
                            <input type=""hidden"" name=""business"" value="" "">
                            <input type=""hidden"" name=""item_name"" value=""Wing Sneakers"">
                            <input type=""hidden"" name=""amount"" value=""650.00"">
                            <input type=""hidden"" name=""discount_amount"" value=""1.00"">
                            <input type=""hidden"" name=""currency_code"" value=""USD"">
                            <input type=""hidden"" name=""return"" value="" "">
                         ");
            WriteLiteral(@"   <input type=""hidden"" name=""cancel_return"" value="" "">
                            <input type=""button"" name=""submit"" id=""btnThemVaoGioHang"" value=""Thêm vào giỏ hàng"" class=""button"">
                        </fieldset>
                    </form>
                </div>

            </div>
");
            EndContext();
            BeginContext(7993, 589, true);
            WriteLiteral(@"
        </div>
        <div class=""clearfix""> </div>
        <!-- /new_arrivals -->
        <div class=""responsive_tabs_agileits"">
            <div id=""horizontalTab"">
                <ul class=""resp-tabs-list"">
                    <li>Mô tả</li>
                    <li>Đánh giá</li>
                    <li>Người bán hàng</li>
                </ul>
                <div class=""resp-tabs-container"">
                    <!--/tab_one-->
                    <div class=""tab1"">
                        <div class=""single_page_agile_its_w3ls"">
                            <h6>");
            EndContext();
            BeginContext(8583, 16, false);
#line 184 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                           Write(Model.TenSanPham);

#line default
#line hidden
            EndContext();
            BeginContext(8599, 38, true);
            WriteLiteral("</h6>\r\n                            <p>");
            EndContext();
            BeginContext(8638, 13, false);
#line 185 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                          Write(Model.ChiTiet);

#line default
#line hidden
            EndContext();
            BeginContext(8651, 2692, true);
            WriteLiteral(@"</p>
                        </div>
                    </div>
                    <!--//tab_one-->
                    <div class=""tab2"">

                        <div class=""single_page_agile_its_w3ls"">
                            <div class=""bootstrap-tab-text-grids"">
                                <div class=""bootstrap-tab-text-grid"">
                                    <div class=""bootstrap-tab-text-grid-left"">
                                        <img src=""images/t1.jpg"" alt="" "" class=""img-responsive"">
                                    </div>
                                    <div class=""bootstrap-tab-text-grid-right"">
                                        <ul>
                                            <li><a href=""#"">Admin</a></li>
                                            <li><a href=""#""><i class=""fa fa-reply-all"" aria-hidden=""true""></i> Reply</a></li>
                                        </ul>
                                        <p>
                             ");
            WriteLiteral(@"               Lorem ipsum dolor sit amet, consectetur adipisicing elPellentesque vehicula augue eget.Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis
                                            suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem
                                            vel eum iure reprehenderit.
                                        </p>
                                    </div>
                                    <div class=""clearfix""> </div>
                                </div>
                                <div class=""add-review"">
                                    <h4>add a review</h4>
                                    <form action=""#"" method=""post"">
                                        <input type=""text"" name=""Name"" required=""Name"">
                                        <input type=""email"" name=""Email"" required=""Email"">
                                        <textarea name=""Message"" required=""""></textarea>
     ");
            WriteLiteral(@"                                   <input type=""submit"" value=""SEND"">
                                    </form>
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- Tab three -->
                    <div class=""tab3"">
                        <div class=""single_page_agile_its_w3ls"">
                            <div class=""icon_nguoibanhang"">
                                <i class=""fa fa-bank""></i>
                            </div>
                            <div class=""tenshop"">
                                <h6>");
            EndContext();
            BeginContext(11344, 34, false);
#line 230 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                               Write(Model.IdTaiKhoanNavigation.TenShop);

#line default
#line hidden
            EndContext();
            BeginContext(11378, 269, true);
            WriteLiteral(@"</h6>
                                <input type=""submit"" value=""Xem Shop"">
                            </div>
                            <div class=""clearfix""></div>
                            <p class=""w3ls_para""><span style=""color: #666666;"">Địa chỉ :</span> ");
            EndContext();
            BeginContext(11648, 33, false);
#line 234 "F:\ASP.NET\TMDT\Project\SneakerC2C\SneakerC2C\Areas\Customer\Views\SanPham\Index.cshtml"
                                                                                           Write(Model.IdTaiKhoanNavigation.DiaChi);

#line default
#line hidden
            EndContext();
            BeginContext(11681, 10573, true);
            WriteLiteral(@"</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- //new_arrivals -->
        <!--/slider_owl-->

        <div class=""w3_agile_latest_arrivals"">
            <h3 class=""wthree_text_info"">Featured <span>Arrivals</span></h3>
            <div class=""col-md-3 product-men single"">
                <div class=""men-pro-item simpleCart_shelfItem"">
                    <div class=""men-thumb-item"">
                        <img src=""images/w2.jpg"" alt="""" class=""pro-image-front"">
                        <img src=""images/w2.jpg"" alt="""" class=""pro-image-back"">
                        <div class=""men-cart-pro"">
                            <div class=""inner-men-cart-pro"">
                                <a href=""single.html"" class=""link-product-add-cart"">Quick View</a>
                            </div>
                        </div>
                        <span class=""product-new-top"">New</span>

                    </div>");
            WriteLiteral(@"
                    <div class=""item-info-product "">
                        <h4><a href=""single.html"">Sleeveless Solid Blue Top</a></h4>
                        <div class=""info-product-price"">
                            <span class=""item_price"">$140.99</span>
                            <del>$189.71</del>
                        </div>
                        <div class=""snipcart-details top_brand_home_details item_add single-item hvr-outline-out button2"">
                            <form action=""#"" method=""post"">
                                <fieldset>
                                    <input type=""hidden"" name=""cmd"" value=""_cart"">
                                    <input type=""hidden"" name=""add"" value=""1"">
                                    <input type=""hidden"" name=""business"" value="" "">
                                    <input type=""hidden"" name=""item_name"" value=""Sleeveless Solid Blue Top"">
                                    <input type=""hidden"" name=""amount"" value=""30.99"">
");
            WriteLiteral(@"                                    <input type=""hidden"" name=""discount_amount"" value=""1.00"">
                                    <input type=""hidden"" name=""currency_code"" value=""USD"">
                                    <input type=""hidden"" name=""return"" value="" "">
                                    <input type=""hidden"" name=""cancel_return"" value="" "">
                                    <input type=""submit"" name=""submit"" value=""Thêm vào giỏ hàng"" class=""button"">
                                </fieldset>
                            </form>
                        </div>

                    </div>
                </div>
            </div>
            <div class=""col-md-3 product-men single"">
                <div class=""men-pro-item simpleCart_shelfItem"">
                    <div class=""men-thumb-item"">
                        <img src=""images/w4.jpg"" alt="""" class=""pro-image-front"">
                        <img src=""images/w4.jpg"" alt="""" class=""pro-image-back"">
                        <div ");
            WriteLiteral(@"class=""men-cart-pro"">
                            <div class=""inner-men-cart-pro"">
                                <a href=""single.html"" class=""link-product-add-cart"">Quick View</a>
                            </div>
                        </div>
                        <span class=""product-new-top"">New</span>

                    </div>
                    <div class=""item-info-product "">
                        <h4><a href=""single.html"">Black Basic Shorts</a></h4>
                        <div class=""info-product-price"">
                            <span class=""item_price"">$120.99</span>
                            <del>$189.71</del>
                        </div>
                        <div class=""snipcart-details top_brand_home_details item_add single-item hvr-outline-out button2"">
                            <form action=""#"" method=""post"">
                                <fieldset>
                                    <input type=""hidden"" name=""cmd"" value=""_cart"">
                      ");
            WriteLiteral(@"              <input type=""hidden"" name=""add"" value=""1"">
                                    <input type=""hidden"" name=""business"" value="" "">
                                    <input type=""hidden"" name=""item_name"" value=""Black Basic Shorts"">
                                    <input type=""hidden"" name=""amount"" value=""30.99"">
                                    <input type=""hidden"" name=""discount_amount"" value=""1.00"">
                                    <input type=""hidden"" name=""currency_code"" value=""USD"">
                                    <input type=""hidden"" name=""return"" value="" "">
                                    <input type=""hidden"" name=""cancel_return"" value="" "">
                                    <input type=""submit"" name=""submit"" value=""Thêm vào giỏ hàng"" class=""button"">
                                </fieldset>
                            </form>
                        </div>

                    </div>
                </div>
            </div>
            <div class=""col-m");
            WriteLiteral(@"d-3 product-men single"">
                <div class=""men-pro-item simpleCart_shelfItem"">
                    <div class=""men-thumb-item"">
                        <img src=""images/s6.jpg"" alt="""" class=""pro-image-front"">
                        <img src=""images/s6.jpg"" alt="""" class=""pro-image-back"">
                        <div class=""men-cart-pro"">
                            <div class=""inner-men-cart-pro"">
                                <a href=""single.html"" class=""link-product-add-cart"">Quick View</a>
                            </div>
                        </div>
                        <span class=""product-new-top"">New</span>

                    </div>
                    <div class=""item-info-product "">
                        <h4><a href=""single.html"">Aero Canvas Loafers  </a></h4>
                        <div class=""info-product-price"">
                            <span class=""item_price"">$120.99</span>
                            <del>$199.71</del>
                        </div>");
            WriteLiteral(@"
                        <div class=""snipcart-details top_brand_home_details item_add single-item hvr-outline-out button2"">
                            <form action=""#"" method=""post"">
                                <fieldset>
                                    <input type=""hidden"" name=""cmd"" value=""_cart"">
                                    <input type=""hidden"" name=""add"" value=""1"">
                                    <input type=""hidden"" name=""business"" value="" "">
                                    <input type=""hidden"" name=""item_name"" value=""Aero Canvas Loafers"">
                                    <input type=""hidden"" name=""amount"" value=""30.99"">
                                    <input type=""hidden"" name=""discount_amount"" value=""1.00"">
                                    <input type=""hidden"" name=""currency_code"" value=""USD"">
                                    <input type=""hidden"" name=""return"" value="" "">
                                    <input type=""hidden"" name=""cancel_return"" value=");
            WriteLiteral(@""" "">
                                    <input type=""submit"" name=""submit"" value=""Thêm vào giỏ hàng"" class=""button"">
                                </fieldset>
                            </form>
                        </div>

                    </div>
                </div>
            </div>
            <div class=""col-md-3 product-men single"">
                <div class=""men-pro-item simpleCart_shelfItem"">
                    <div class=""men-thumb-item"">
                        <img src=""images/w7.jpg"" alt="""" class=""pro-image-front"">
                        <img src=""images/w7.jpg"" alt="""" class=""pro-image-back"">
                        <div class=""men-cart-pro"">
                            <div class=""inner-men-cart-pro"">
                                <a href=""single.html"" class=""link-product-add-cart"">Quick View</a>
                            </div>
                        </div>
                        <span class=""product-new-top"">New</span>

                    </div>
     ");
            WriteLiteral(@"               <div class=""item-info-product "">
                        <h4><a href=""single.html"">Ankle Length Socks</a></h4>
                        <div class=""info-product-price"">
                            <span class=""item_price"">$100.99</span>
                            <del>$159.71</del>
                        </div>
                        <div class=""snipcart-details top_brand_home_details item_add single-item hvr-outline-out button2"">
                            <form action=""#"" method=""post"">
                                <fieldset>
                                    <input type=""hidden"" name=""cmd"" value=""_cart"">
                                    <input type=""hidden"" name=""add"" value=""1"">
                                    <input type=""hidden"" name=""business"" value="" "">
                                    <input type=""hidden"" name=""item_name"" value=""Ankle Length Socks"">
                                    <input type=""hidden"" name=""amount"" value=""30.99"">
                     ");
            WriteLiteral(@"               <input type=""hidden"" name=""discount_amount"" value=""1.00"">
                                    <input type=""hidden"" name=""currency_code"" value=""USD"">
                                    <input type=""hidden"" name=""return"" value="" "">
                                    <input type=""hidden"" name=""cancel_return"" value="" "">
                                    <input type=""submit"" name=""submit"" value=""Thêm vào giỏ hàng"" class=""button"">
                                </fieldset>
                            </form>
                        </div>

                    </div>
                </div>
            </div>
            <div class=""clearfix""> </div>
            <!--//slider_owl-->
        </div>
    </div>
</div>
<!--//single_page-->
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>
<script>
    $(""#btnThemVaoGioHang"").click(function(){
        let idsizesanpham = $(""#sltSizeSanPham option:selected"").val();
        $.ajax({
           ");
            WriteLiteral(@" url: ""/Customer/TaiKhoan/AddToCart"",
            type: ""post"",
            data: { ""idsizesanpham"": idsizesanpham },
            success: function (data) {
                alert(data);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.Database.SanPham> Html { get; private set; }
    }
}
#pragma warning restore 1591
