#pragma checksum "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f76d0eb547e5edda3802e0a39d3040c950b4dd4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f76d0eb547e5edda3802e0a39d3040c950b4dd4f", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f42faec34fafac4f774181701c26adb1205f372e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ME_Mall.Models.FeedbackUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cart-btn btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
  
    ViewData["Title"] = "About Us";
    Layout = "~/Views/Shared/_MainLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- breadcrumb-section -->
<div class=""breadcrumb-section breadcrumb-bg"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-8 offset-lg-2 text-center"">
                <div class=""breadcrumb-text"">
                    <p>All that you need at one place</p>
                    <h1>About Us</h1>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- end breadcrumb section -->
<!-- featured section -->
<div class=""feature-bg"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-7"">
                <div class=""featured-text"">
                    <h2 class=""pb-3"">Why <span class=""orange-text"">MEMall</span></h2>
                    <div class=""row"">
                        <div class=""col-lg-6 col-md-6 mb-4 mb-md-5"">
                            <div class=""list-box d-flex"">
                                <div class=""list-icon"">
                                    <i class=""fas fa-shipping-fast""><");
            WriteLiteral(@"/i>
                                </div>
                                <div class=""content"">
                                    <h3>Home Delivery</h3>
                                    <p>Get your order within 1-2 hours with our delivery system.</p>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6 col-md-6 mb-5 mb-md-5"">
                            <div class=""list-box d-flex"">
                                <div class=""list-icon"">
                                    <i class=""fas fa-money-bill-alt""></i>
                                </div>
                                <div class=""content"">
                                    <h3>Best Price</h3>
                                    <p>If you do care about the price then you are at the right place.</p>
                                </div>
                            </div>
                        </div>
                        <");
            WriteLiteral(@"div class=""col-lg-6 col-md-6 mb-5 mb-md-5"">
                            <div class=""list-box d-flex"">
                                <div class=""list-icon"">
                                    <i class=""fas fa-briefcase""></i>
                                </div>
                                <div class=""content"">
                                    <h3>High Quality</h3>
                                    <p>We prepare your order with love, we deliver with love.</p>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6 col-md-6"">
                            <div class=""list-box d-flex"">
                                <div class=""list-icon"">
                                    <i class=""fas fa-sync-alt""></i>
                                </div>
                                <div class=""content"">
                                    <h3>Quick Refund</h3>
                                    ");
            WriteLiteral(@"<p>If you had a problem with your order you can ask for a refund, It is all about you.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- end featured section -->
<!-- shop banner -->
");
#nullable restore
#line 82 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
 if (@ViewBag.show == true)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <section class=\"shop-banner\"");
            BeginWriteAttribute("style", " style=\"", 3643, "\"", 3701, 3);
            WriteAttributeValue("", 3651, "background-image:url(\'/Images/Ads/", 3651, 34, true);
#nullable restore
#line 84 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
WriteAttributeValue("", 3685, ViewBag.adImg, 3685, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3699, "\')", 3699, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"container\">\r\n            <h3>");
#nullable restore
#line 86 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
           Write(ViewBag.text1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br> ");
#nullable restore
#line 86 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
                               Write(ViewBag.text2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"orange-text\">");
#nullable restore
#line 86 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
                                                                        Write(ViewBag.orangeText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h3>\r\n            <div class=\"sale-percent\"><span>Sale! <br> Upto</span>");
#nullable restore
#line 87 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
                                                             Write(ViewBag.discount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span>off</span></div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f76d0eb547e5edda3802e0a39d3040c950b4dd4f10726", async() => {
                WriteLiteral("Shop Now");
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
            WriteLiteral("\r\n        </div>\r\n    </section>\r\n");
#nullable restore
#line 91 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- end shop banner -->
<!-- team section -->
<div class=""mt-150 mb-150"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-8 offset-lg-2 text-center"">
                <div class=""section-title"">
                    <h3>Our <span class=""orange-text"">Team</span></h3>
                    <p>Our team's mission is to deliver the best. Get to know them.</p>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-4 col-md-6"">
                <div class=""single-team-item"">
                    <div class=""team-bg team-bg-1""></div>
                    <h4>Ellen Alaishat <span>Vice president</span></h4>
                    <ul class=""social-link-team"">
                        <li><a href=""#"" target=""_blank""><i class=""fab fa-facebook-f""></i></a></li>
                        <li><a href=""#"" target=""_blank""><i class=""fab fa-twitter""></i></a></li>
                        <li><a href=""#"" target=""_blank""><i class");
            WriteLiteral(@"=""fab fa-instagram""></i></a></li>
                    </ul>
                </div>
            </div>
            <div class=""col-lg-4 col-md-6"">
                <div class=""single-team-item"">
                    <div class=""team-bg team-bg-2""></div>
                    <h4>Mahmoud Alaishat <span>CEO</span></h4>
                    <ul class=""social-link-team"">
                        <li><a href=""#"" target=""_blank""><i class=""fab fa-facebook-f""></i></a></li>
                        <li><a href=""#"" target=""_blank""><i class=""fab fa-twitter""></i></a></li>
                        <li><a href=""#"" target=""_blank""><i class=""fab fa-instagram""></i></a></li>
                    </ul>
                </div>
            </div>
            <div class=""col-lg-4 col-md-6 offset-md-3 offset-lg-0"">
                <div class=""single-team-item"">
                    <div class=""team-bg team-bg-3""></div>
                    <h4>Jawad Noor <span>CTO</span></h4>
                    <ul class=""social-link-team"">
            WriteLiteral(@"
                        <li><a href=""#"" target=""_blank""><i class=""fab fa-facebook-f""></i></a></li>
                        <li><a href=""#"" target=""_blank""><i class=""fab fa-twitter""></i></a></li>
                        <li><a href=""#"" target=""_blank""><i class=""fab fa-instagram""></i></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- end team section -->
<!-- testimonail-section -->
");
#nullable restore
#line 143 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
 if (@ViewBag.feedCount > 1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"testimonail-section mt-80 mb-150\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-lg-10 offset-lg-1 text-center\">\r\n                    <div class=\"testimonial-sliders\">\r\n");
#nullable restore
#line 150 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"single-testimonial-slider\">\r\n                                <div class=\"client-avater\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f76d0eb547e5edda3802e0a39d3040c950b4dd4f15967", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 7120, "~/Images/", 7120, 9, true);
#nullable restore
#line 154 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
AddHtmlAttributeValue("", 7129, item.User.ProfilePath, 7129, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"client-meta\">\r\n                                    <h3>\r\n                                        ");
#nullable restore
#line 158 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
                                   Write(item.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 158 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
                                                         Write(item.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  <span>Customer</span>\r\n                                    </h3>\r\n                                    <p class=\"testimonial-body\">\r\n                                        \" ");
#nullable restore
#line 161 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
                                     Write(item.Feedback.FeedbackText);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ""
                                    </p>
                                    <div class=""last-icon"">
                                        <i class=""fas fa-quote-right""></i>
                                    </div>
                                </div>
                            </div>
");
#nullable restore
#line 168 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 175 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Home\About.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- end testimonail-section -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ME_Mall.Models.FeedbackUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591