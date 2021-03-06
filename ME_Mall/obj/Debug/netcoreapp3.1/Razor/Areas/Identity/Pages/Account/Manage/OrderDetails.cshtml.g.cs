#pragma checksum "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4373473fd3df774131bc4f5f3e3d4150f3735741"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_Manage_OrderDetails), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Manage/OrderDetails.cshtml")]
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
#line 1 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\_ViewImports.cshtml"
using ME_Mall;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Ataa.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using Ataa.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4373473fd3df774131bc4f5f3e3d4150f3735741", @"/Areas/Identity/Pages/Account/Manage/OrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"288af974675145667b972ae69913689985144d24", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ddbd8bcbf695cc40061374b8cdc67f9c332c5ed", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"310197ed3619b84195611925b064a5780c548f0f", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage_OrderDetails : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Orders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
  
    ViewData["Title"] = "Order Details";
    ViewData["ActivePage"] = ManageNavPages.Orders;
    Layout = "~/Views/Shared/_UserLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .dt-buttons {
        margin-top:8px;
        margin-left: 16px;
    }

</style>

<div class=""container-xxl flex-grow-1 container-p-y"">

    <!-- Basic Bootstrap Table -->
    <div class=""card"">
        <div class=""table-responsive text-nowrap"">
            <table class=""table"" id=""example"" style=""width:100%"">
                <caption style=""caption-side:top;margin-left:17px"">
                    <h6 class=""text-muted mt-4 mb-0 mr-3"">Order ID: ");
#nullable restore
#line 23 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                                               Write(Model.Order.Select(x => x.order.Id).First());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6><br />\r\n                    <h6 class=\"text-muted mb-0 mr-3\">Order Date: ");
#nullable restore
#line 24 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                                            Write(Model.Order.Select(x => x.order.OrderDate).First());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6><br />\r\n                    <h6 class=\"text-muted mb-2 mr-3\">Order Address: ");
#nullable restore
#line 25 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                                               Write(Model.Order.Select(x => x.order.OrderAddress).First());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                </caption>
                <thead>
                    <tr>
                        <th>
                            Product Name
                        </th>

                        <th>
                            Price
                        </th>
                        <th>
                            Quantity
                        </th>
                        <th>
                            Grand Total
                        </th>
                    </tr>
                </thead>

                <tbody class=""table-border-bottom-0"">
");
#nullable restore
#line 46 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                     foreach (var item in Model.Order)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                <i class=\"fab fa-react fa-lg text-info \"></i> <strong>");
#nullable restore
#line 50 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                                                                 Write(Html.DisplayFor(modelItem => item.product.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                            </td>\r\n                            <td>\r\n                                <i class=\"fab fa-react fa-lg text-info me-1\"></i> <strong>");
#nullable restore
#line 53 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                                                                     Write(Html.DisplayFor(modelItem => item.product.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 56 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                  
                                    string unit = item.Unit.UnitName;
                                    List<string> u = new List<string> { "Kg" };
                                    if (u.Contains(unit))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <i class=\"fab fa-react fa-lg text-info me-1\"></i> <strong>");
#nullable restore
#line 61 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                                                                             Write(Html.DisplayFor(modelItem => item.orderProduct.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n");
#nullable restore
#line 62 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <i class=\"fab fa-react fa-lg text-info me-1\"></i> <strong>");
#nullable restore
#line 65 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                                                                             Write(Html.DisplayFor(modelItem => item.orderProduct.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n");
#nullable restore
#line 66 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                    }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>\r\n                                <i class=\"fab fa-react fa-lg text-info me-1\"></i> <strong>");
#nullable restore
#line 70 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                                                                     Write(Html.DisplayFor(modelItem => item.orderProduct.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 73 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <tr class=""table-info"">
                        <td>
                            <i class=""fab fa-react fa-lg text-info ""></i> <strong>Shipping</strong>
                        </td>
                        <td></td>
                        <td></td>
                        <td>
                            <i class=""fab fa-react fa-lg text-info me-2""></i> <strong>2</strong>
                        </td>
                    </tr>
                </tbody>
                <tfoot class=""table-dark"" style=""width:100%"">
                    <tr>
                        <td>
                            <i class=""fab fa-react fa-lg text-info""></i> <strong>Order Total: ");
#nullable restore
#line 88 "C:\Users\Lenovo\source\repos\ME_Mall\ME_Mall\Areas\Identity\Pages\Account\Manage\OrderDetails.cshtml"
                                                                                         Write(Model.Order.Select(x => x.order.TotalPrice).First());

#line default
#line hidden
#nullable disable
            WriteLiteral(" JOD</strong>\r\n");
            WriteLiteral(@"                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </tfoot>
            </table>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4373473fd3df774131bc4f5f3e3d4150f373574113101", async() => {
                WriteLiteral("<i class=\"bx bx-arrow-back bx-tada\"></i> Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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



<script>
    document.addEventListener('DOMContentLoaded', function () {
        let table = new DataTable('#example', {
            dom: 'Bfrtip',
            buttons: [
                { extend: 'copyHtml5', footer: true },
                { extend: 'excelHtml5', footer: true },
                { extend: 'csvHtml5', footer: true },
                { extend: 'pdfHtml5', footer: true },

            ],
            paging: false,
            ordering: false,
            info: false,
            searching: false
        });
    });

</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ataa.Areas.Identity.Pages.Account.Manage.OrderDetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Ataa.Areas.Identity.Pages.Account.Manage.OrderDetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Ataa.Areas.Identity.Pages.Account.Manage.OrderDetailsModel>)PageContext?.ViewData;
        public Ataa.Areas.Identity.Pages.Account.Manage.OrderDetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
