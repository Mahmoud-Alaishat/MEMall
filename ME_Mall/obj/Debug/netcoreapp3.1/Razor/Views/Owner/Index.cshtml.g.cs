#pragma checksum "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "781be4ee1f8f08142358c13b018da2433f86d272"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Owner_Index), @"mvc.1.0.view", @"/Views/Owner/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\_ViewImports.cshtml"
using ME_Mall;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\_ViewImports.cshtml"
using ME_Mall.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"781be4ee1f8f08142358c13b018da2433f86d272", @"/Views/Owner/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f42faec34fafac4f774181701c26adb1205f372e", @"/Views/_ViewImports.cshtml")]
    public class Views_Owner_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ME_Mall.Controllers.OwnerController.OrderStatisticsData>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RevenueReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Owner", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/dashAssets1/assets/img/illustrations/manup2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("140"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("View Badge User"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-app-dark-img", new global::Microsoft.AspNetCore.Html.HtmlString("illustrations/man-with-laptop-dark.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-app-light-img", new global::Microsoft.AspNetCore.Html.HtmlString("illustrations/man-with-laptop-light.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Views/Shared/_OwnerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Content wrapper -->
<div class=""content-wrapper"">
    <!-- Content -->

    <div class=""container-xxl flex-grow-1 container-p-y"">
        <div class=""row"">
            <div class=""col-lg-8 mb-4 order-0"">
                <div class=""card"">
                    <div class=""d-flex align-items-end row"">
                        <div class=""col-sm-7"">
                            <div class=""card-body"">
                                <h5 class=""card-title text-primary"">Welcome ");
#nullable restore
#line 19 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
                                                                       Write(ViewBag.fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" 🎉</h5>
                                <p class=""mb-4"">
                                    <span class=""fw-bold"">Here you can manage your store</span>
                                    , add products, and monitor your store' performance
                                </p>

                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "781be4ee1f8f08142358c13b018da2433f86d2727849", async() => {
                WriteLiteral("View Sales");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-sm-5 text-center text-sm-left\">\r\n                            <div class=\"card-body pb-0 px-0 px-md-4\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "781be4ee1f8f08142358c13b018da2433f86d2729553", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-md-4 order-1"">
                <div class=""row"">
                    <div class=""col-lg-6 col-md-12 col-6 mb-4"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <div class=""card-title d-flex align-items-start justify-content-between"">
                                    <div class=""avatar flex-shrink-0"">
                                        <i style=""color: #F28123"" class='bx bxs-category bx-md'></i>
                                    </div>

                                </div>
                                <span class=""fw-semibold d-block mb-1"">Products</span>
                                <h3 class=""card-title mb-2"">");
#nullable restore
#line 52 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
                                                       Write(ViewBag.products);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                            </div>
                        </div>
                    </div>
                    <div class=""col-lg-6 col-md-12 col-6 mb-4"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <div class=""card-title d-flex align-items-start justify-content-between"">
                                    <div class=""avatar flex-shrink-0"">
                                        <i style=""color: #F28123"" class='bx bxs-category-alt bx-md'></i>
                                    </div>

                                </div>
                                <span class=""fw-semibold d-block mb-1"">Categories</span>
                                <h3 class=""card-title mb-2"">");
#nullable restore
#line 66 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
                                                       Write(ViewBag.subcategories);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Total Revenue -->
            <div class=""col-12 col-lg-8 order-2 order-md-3 order-lg-2 mb-4"">
                <div class=""card"">
                    <div class=""row row-bordered g-0"">
                        <div class=""col-md-12"">
                            <h5 class=""card-header m-0 me-2 pb-3"">Total Revenue</h5>
                            <div id=""totalRevenueChart"" class=""px-2""></div>
                        </div>
                    </div>
                </div>
            </div>
            <!--/ Total Revenue -->
            <div class=""col-12 col-md-8 col-lg-4 order-3 order-md-2"">
                <div class=""row"">
                    <div class=""col-6 mb-4"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <div class=""card-title d-flex align-i");
            WriteLiteral(@"tems-start justify-content-between"">
                                    <div class=""avatar flex-shrink-0"">
                                        <i style=""color: #F28123"" class='bx bx-money bx-md'></i>
                                    </div>
                                </div>
                                <span class=""d-block mb-1"">Revenue</span>
                                <h3 class=""card-title text-nowrap mb-2"">");
#nullable restore
#line 95 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
                                                                   Write(ViewBag.revenue);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                            </div>
                        </div>
                    </div>
                    <div class=""col-6 mb-4"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <div class=""card-title d-flex align-items-start justify-content-between"">
                                    <div class=""avatar flex-shrink-0"">
                                        <i style=""color: #F28123"" class='bx bxs-cart bx-md'></i>
                                    </div>
                                </div>
                                <span class=""fw-semibold d-block mb-1"">Orders</span>
                                <h3 class=""card-title mb-2"">");
#nullable restore
#line 108 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
                                                       Write(ViewBag.total);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                            </div>
                        </div>
                    </div>
                    <!-- </div>
                    <div class=""row""> -->
                    <div class=""col-12 mb-4"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <div class=""d-flex justify-content-between flex-sm-row flex-column gap-3"">
                                    <div class=""d-flex flex-sm-column flex-row align-items-start justify-content-between"">
                                        <div class=""card-title"">
                                            <h5 class=""text-nowrap mb-md-5 mb-sm-4"">
                                                Total Revenue
                                            </h5>
                                            <span class=""badge bg-label-primary rounded-pill"">Year 2022</span>
                                        </div>
                                        <di");
            WriteLiteral("v class=\"mt-sm-auto\">\r\n                                            <h3 class=\"mb-0\">");
#nullable restore
#line 126 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
                                                        Write(ViewBag.revenue);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                        </div>
                                    </div>
                                    <div id=""profileReportChart""></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"">
            <!-- Order Statistics -->
            <div class=""col-md-12 col-lg-12 col-xl-12 order-0 mb-4"">
                <div class=""card h-100"">
                    <div class=""card-header d-flex align-items-center justify-content-between pb-0"">
                        <div class=""card-title mb-0"">
                            <h5 class=""m-0 me-2"">Order Statistics</h5>
                        </div>
                        
                    </div>
                    <div class=""card-body"">
                        <div class=""d-flex justify-content-between align-items-center mb-3"">
                        ");
            WriteLiteral("    <div class=\"d-flex flex-column align-items-center gap-1\">\r\n                                <h2 class=\"mb-2\">");
#nullable restore
#line 150 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
                                            Write(ViewBag.total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                                <span>Total Orders</span>\r\n                            </div>\r\n                            <div id=\"orderStatisticsChart\"></div>\r\n                        </div>\r\n                        <ul class=\"p-0 m-0\">\r\n");
#nullable restore
#line 156 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <li class=""d-flex mb-4 pb-1"">
                                    <div class=""avatar flex-shrink-0 me-3"">
                                        <span class=""avatar-initial rounded bg-label-primary"">
                                            <i class=""bx bx-shopping-bag""></i>
                                        </span>
                                    </div>
                                    <div class=""d-flex w-100 flex-wrap align-items-center justify-content-between gap-2"">
                                        <div class=""me-2"">
                                            <h6 class=""mb-0"">");
#nullable restore
#line 166 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
                                                        Write(item.labels);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                        </div>\r\n                                        <div class=\"user-progress\">\r\n                                            <small class=\"fw-semibold\">");
#nullable restore
#line 169 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
                                                                  Write(item.data);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                                        </div>\r\n                                    </div>\r\n                                </li>\r\n");
#nullable restore
#line 173 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Owner\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </ul>
                    </div>
                </div>
            </div>
            <!--/ Order Statistics -->
        </div>
    </div>
    <!-- / Content -->
    <!-- Footer -->
    <footer class=""content-footer footer bg-footer-theme"">
        <div class=""container-xxl d-flex flex-wrap justify-content-between py-2 flex-md-row flex-column"">
            <div class=""mb-2 mb-md-0"">
                <i class='bx bxs-battery-charging'></i> Powered by
                <a style=""pointer-events: none"" href=""#"" target=""_blank"" class=""footer-link fw-bolder"">Mahmoud Alaishat</a>
            </div>
        </div>
    </footer>
    <!-- / Footer -->

    <div class=""content-backdrop fade""></div>
</div>
<!-- Content wrapper -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ME_Mall.Controllers.OwnerController.OrderStatisticsData>> Html { get; private set; }
    }
}
#pragma warning restore 1591