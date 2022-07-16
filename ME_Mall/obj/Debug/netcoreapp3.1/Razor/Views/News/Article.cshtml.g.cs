#pragma checksum "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29037185d7d3c1a57457dec313efce32720bd84c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_Article), @"mvc.1.0.view", @"/Views/News/Article.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29037185d7d3c1a57457dec313efce32720bd84c", @"/Views/News/Article.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f42faec34fafac4f774181701c26adb1205f372e", @"/Views/_ViewImports.cshtml")]
    public class Views_News_Article : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<ArticleUser, List<NewsAndArticles>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Article", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "News", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
      
        ViewData["Title"] = "Article Details";
        Layout = "~/Views/Shared/_MainLayout.cshtml";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <style>\r\n    .single-artcile-bg {\r\n        background-size: cover;\r\n        background-position: center;\r\n        background-color: #ddd;\r\n        border-radius: 5px;\r\n        margin-bottom: 20px;\r\n        background-image: url(\'/Images/Articles/");
#nullable restore
#line 14 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                                           Write(Model.Item1.NewsAndArticles.PostImg);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
        height: 450px;
    }
    </style>
    <!-- breadcrumb-section -->
    <div class=""breadcrumb-section breadcrumb-bg"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-8 offset-lg-2 text-center"">
                    <div class=""breadcrumb-text"">
                        <p>Read the Details</p>
                        <h1>Full Article</h1>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- end breadcrumb section -->
    <!-- single article section -->
    <div class=""mt-150 mb-150"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-8"">
                    <div class=""single-article-section"">
                        <div class=""single-article-text"">
                            <div class=""single-artcile-bg""></div>
                            <p class=""blog-meta"">
                                <span class=""author""><i class=""fas f");
            WriteLiteral("a-user\"></i> ");
#nullable restore
#line 41 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                                                                            Write(Model.Item1.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 41 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                                                                                                        Write(Model.Item1.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <span class=\"date\"><i class=\"fas fa-calendar\"></i> ");
#nullable restore
#line 42 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                                                                              Write(Model.Item1.NewsAndArticles.PostDate.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 42 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                                                                                                                        Write(ViewBag.month);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 42 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                                                                                                                                        Write(Model.Item1.NewsAndArticles.PostDate.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </p>\r\n                            <h2>");
#nullable restore
#line 44 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                           Write(Model.Item1.NewsAndArticles.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                            <p style=\" white-space: pre-wrap;\">");
#nullable restore
#line 45 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                                                          Write(Model.Item1.NewsAndArticles.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n\r\n");
            WriteLiteral(@"                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""sidebar-section"">
                        <div class=""recent-posts"">
                            <h4>Recent Posts</h4>
                            <ul>
");
#nullable restore
#line 100 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                                 foreach (var item in Model.Item2)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "29037185d7d3c1a57457dec313efce32720bd84c9042", async() => {
#nullable restore
#line 102 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                                                                                                     Write(item.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 102 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                                                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 103 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\News\Article.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n                        </div>\r\n");
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- end single article section -->\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<ArticleUser, List<NewsAndArticles>>> Html { get; private set; }
    }
}
#pragma warning restore 1591