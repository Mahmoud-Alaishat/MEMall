#pragma checksum "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Media\ArticlePreview.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3eaa90cd348b468b174c1f3a56535ba38a03e537"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Media_ArticlePreview), @"mvc.1.0.view", @"/Views/Media/ArticlePreview.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3eaa90cd348b468b174c1f3a56535ba38a03e537", @"/Views/Media/ArticlePreview.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f42faec34fafac4f774181701c26adb1205f372e", @"/Views/_ViewImports.cshtml")]
    public class Views_Media_ArticlePreview : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ME_Mall.Models.NewsAndArticles>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Articles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Media", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Media\ArticlePreview.cshtml"
  
    ViewData["Title"] = "Article Preview";
    Layout = "~/Views/Shared/_ContentWriterLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .shop-banner {
        position: relative;
        background-color: #f5f5f5;
        background-size: cover;
        padding: 110px 0px 115px;
    }

        .shop-banner h3 {
            position: relative;
            font-size: 50px;
            line-height: 1.2em;
            margin-bottom: 0px;
            color: #000;
            font-weight: bolder
        }

        .shop-banner .sale-percent {
            position: relative;
            font-size: 60px;
            font-weight: 700;
            color: #F28123;
        }

    #discount {
        font-size: 60px;
        font-weight: 700;
        color: #F28123;
    }

    .shop-banner .sale-percent span {
        position: relative;
        font-size: 24px;
        line-height: 1.1em;
        color: #051922;
        font-weight: 400;
        text-align: center;
        margin-right: 10px;
        display: inline-block;
    }

    a.cart-btn {
        border-radius: 50px;
        border-color: tra");
            WriteLiteral(@"nsparent;
        background-color: #F28123;
        color: #fff
    }

        a.cart-btn:hover {
            background-color: #051922;
            color: #F28123;
        }

    .orange-text {
        color: #F28123;
    }


    .latest-news-bg {
        height: 200px;
        background-size: cover;
        background-position: center;
        border-radius: 10px;
        background-color: #ddd;
        border-bottom-right-radius: 0;
        border-bottom-left-radius: 0;
    }

    .single-latest-news h3 {
        font-size: 20px;
        line-height: 1.25em;
        font-weight: 600;
    }

        .single-latest-news h3 a {
            color: #051922;
        }

    p.blog-meta span {
        margin-right: 15px;
        opacity: 0.6;
        color: #051922;
        font-size: 0.85em;
    }

        p.blog-meta span:last-child {
            margin-right: 0;
        }

        p.blog-meta span i {
            margin-right: 5px;
        }

    p.excerpt {
");
            WriteLiteral(@"        line-height: 1.8;
        color: #555;
    }

    .latest-news a.boxed-btn {
        margin-top: 80px;
    }

    .news-text-box {
        padding: 25px;
        border-bottom-left-radius: 5px;
        border-bottom-right-radius: 5px;
    }

    .single-latest-news {
        margin-bottom: 30px;
    }

    .single-artcile-bg {
        background-size: cover;
        background-position: center;
        background-color: #ddd;
        border-radius: 5px;
        margin-bottom: 20px;
        background-image: url('/Images/Articles/");
#nullable restore
#line 124 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Media\ArticlePreview.cshtml"
                                           Write(Model.PostImg);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
        height: 450px;
    }

    .single-article-text h2 {
        font-size: 24px;
        font-weight: 600;
        line-height: 1.4;
        margin-bottom: 10px;
    }

    .single-article-text p {
        font-size: 15px;
        line-height: 1.6;
        color: #051922;
    }

    .comments-list-wrap {
        margin: 100px 0;
    }

        .comments-list-wrap h3 {
            font-size: 25px;
            font-weight: 600;
            margin-bottom: 50px;
        }

    .comment-template h4 {
        font-size: 25px;
        font-weight: 600;
        margin-bottom: 50px;
    }

    .single-comment-body {
        position: relative;
    }

    .comment-user-avater {
        position: absolute;
        left: 0;
        top: 0;
    }

        .comment-user-avater img {
            width: 60px;
            max-width: 60px;
            border-radius: 50%;
        }

    .comment-text-body {
        padding-left: 80px;
        margin-bottom: 40px;
    }");
            WriteLiteral(@"

        .comment-text-body h4 {
            font-size: 18px;
            font-weight: 600;
        }

    span.comment-date {
        opacity: 0.5;
        font-size: 80%;
        font-weight: 700;
        margin-left: 5px;
    }

    .comment-text-body h4 a {
        color: #051922;
        font-size: 80%;
        margin-left: 10px;
        border-bottom: 1px solid #aaa;
    }

    .single-comment-body.child {
        margin-left: 75px;
    }

    .comment-text-body p {
        color: #888;
        line-height: 2;
        margin: 0;
    }

    .comment-template h4 {
        margin-bottom: 10px;
    }

    .comment-template > p {
        opacity: 0.7;
        margin-bottom: 30px;
    }

    .comment-template form p input[type=text] {
        border: 1px solid #ddd;
        width: 49%;
        padding: 15px;
        border-radius: 5px;
        font-size: 15px;
        color: #051922;
    }

    .comment-template form p input[type=email] {
        border: 1px ");
            WriteLiteral(@"solid #ddd;
        width: 49%;
        padding: 15px;
        border-radius: 5px;
        font-size: 15px;
        color: #051922;
        margin-left: 10px;
    }

    .comment-template form p textarea {
        border: 1px solid #ddd;
        padding: 15px;
        font-size: 15px;
        color: #051922;
        border-radius: 5px;
        height: 250px;
        resize: none;
        width: 100%;
    }

    .sidebar-section {
        margin-left: 30px;
    }

        .sidebar-section h4 {
            font-size: 20px;
            font-weight: 600;
            margin-bottom: 15px;
        }

        .sidebar-section ul {
            margin: 0;
            padding: 0;
            list-style: none;
        }

            .sidebar-section ul li {
                line-height: 1.5;
            }

                .sidebar-section ul li a {
                    color: #555;
                    font-size: 15px;
                    pointer-events: none
                }

");
            WriteLiteral(@"        .sidebar-section > div {
            margin-bottom: 60px;
        }

            .sidebar-section > div:last-child {
                margin-bottom: 0;
            }

    .recent-posts ul li, .archive-posts ul li {
        position: relative;
        padding-left: 17px;
        margin-bottom: 10px;
    }

        .recent-posts ul li:before, .archive-posts ul li:before {
            position: absolute;
            left: 0;
            top: 2px;
            content: ""\f105"";
            font-family: ""Font Awesome 5 Free"";
            font-weight: 900;
        }

    .tag-section ul li {
        display: inline-block;
    }

        .tag-section ul li a {
            background-color: #ddd;
            padding: 3px 10px;
            display: block;
            border-radius: 5px;
            margin-bottom: 10px;
            margin-right: 5px;
        }

    .mt-150 {
        margin-top: 50px;
    }

    .mb-150 {
        margin-bottom: 30px;
    }

    #part2 {");
            WriteLiteral(@"
        word-wrap: break-word;
        white-space: pre-wrap;
    }
</style>
<div class=""container-xxl flex-grow-1 container-p-y"">

    <div class=""mt-3"">
        <!-- Modal -->
        <div  id=""fullscreenModal""  >
            <div>
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""modalFullTitle"">Article Preview</h5>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3eaa90cd348b468b174c1f3a56535ba38a03e53712328", async() => {
                WriteLiteral("<i class=\"bx bx-arrow-back bx-fade-left-hover\"></i> Back");
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
            WriteLiteral(@"
                    </div>
                    <div class=""modal-body"">
                        <div class=""mt-150 mb-150"">
                            <div class=""w-100"" style=""margin:0 auto"">
                                <div class=""row"">
                                    <div class=""col-lg-8"">
                                        <div class=""single-article-section"">
                                            <div class=""single-article-text"">
                                                <div class=""single-artcile-bg"" id=""display-image""></div>
                                                <p class=""blog-meta"">
                                                    <span class=""author""><i class=""fas fa-user""></i> ");
#nullable restore
#line 341 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Media\ArticlePreview.cshtml"
                                                                                                Write(ViewBag.fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                    <span class=\"date\">\r\n                                                        <i class=\"fas fa-calendar\"></i> ");
#nullable restore
#line 343 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Media\ArticlePreview.cshtml"
                                                                                   Write(Model.PostDate.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 343 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Media\ArticlePreview.cshtml"
                                                                                                       Write(ViewBag.month);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 343 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Media\ArticlePreview.cshtml"
                                                                                                                       Write(Model.PostDate.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </span>\r\n                                                </p>\r\n                                                <h2 id=\"part1\" style=\"color:black;font-weight:bold\">");
#nullable restore
#line 346 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Media\ArticlePreview.cshtml"
                                                                                               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                                                <p id=\"part2\">");
#nullable restore
#line 347 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Views\Media\ArticlePreview.cshtml"
                                                         Write(Model.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""col-lg-4"">
                                        <div class=""sidebar-section"">
                                            <div class=""recent-posts"">
                                                <h4>Recent Posts</h4>
                                                <ul>
                                                    <li><a href=""single-news.html"">You will vainly look for fruit on it in autumn.</a></li>
                                                    <li><a href=""single-news.html"">A man's worth has its season, like tomato.</a></li>
                                                    <li><a href=""single-news.html"">Good thoughts bear good fresh juicy fruit.</a></li>
                                                    <li><a href=""single-news.html"">Fall in love with the fresh orange</a></li>
     ");
            WriteLiteral(@"                                               <li><a href=""single-news.html"">Why the berries always look delecious</a></li>
                                                </ul>
                                            </div>
                                            <div class=""archive-posts"">
                                                <h4>Archive Posts</h4>
                                                <ul>
                                                    <li><a href=""single-news.html"">JAN 2019 (5)</a></li>
                                                    <li><a href=""single-news.html"">FEB 2019 (3)</a></li>
                                                    <li><a href=""single-news.html"">MAY 2019 (4)</a></li>
                                                    <li><a href=""single-news.html"">SEP 2019 (4)</a></li>
                                                    <li><a href=""single-news.html"">DEC 2019 (3)</a></li>
                                                </ul>
       ");
            WriteLiteral("                                     </div>\r\n");
            WriteLiteral("                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ME_Mall.Models.NewsAndArticles> Html { get; private set; }
    }
}
#pragma warning restore 1591
