#pragma checksum "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4931451473dba770c6a7601d6139d8d1cdee00e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CustomerDashboard_customerAddress), @"mvc.1.0.view", @"/Views/CustomerDashboard/customerAddress.cshtml")]
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
#line 1 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\_ViewImports.cshtml"
using Helperland_integration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\_ViewImports.cshtml"
using Helperland_integration.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4931451473dba770c6a7601d6139d8d1cdee00e", @"/Views/CustomerDashboard/customerAddress.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52663adf7ad89d70b33d8d4f2ceb5dc376b120f4", @"/Views/_ViewImports.cshtml")]
    public class Views_CustomerDashboard_customerAddress : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserAddress>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/edit-icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/delete-icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation/dist/jquery.validate.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
  
    ViewBag.Title = "Customer Address";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
  
    Layout = null;
    int i = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""right-table address-table "">
                <table class=""table "" >
                  <thead>
                    <tr>
                      <th scope=""col"">Addresses</th>
                      <th scope=""col"">Action</th>
                    </tr>
                  </thead>
                  <tbody>
                    
");
#nullable restore
#line 32 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
                     foreach(UserAddress address in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                     <tr>\r\n                      <td>\r\n                        <div class=\"address\">\r\n                          \r\n                          <p>\r\n                            <span class=\"font-weight-bold\">Address : </span>");
#nullable restore
#line 39 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
                                                                       Write(address.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 39 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
                                                                                              Write(address.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 39 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
                                                                                                                     Write(address.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 39 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
                                                                                                                                   Write(address.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(".\r\n                          </p>\r\n                          <p><span class=\"font-weight-bold\">Phone number : </span>");
#nullable restore
#line 41 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
                                                                             Write(address.Mobile);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </div>
                      </td>

                      <td class=""d-flex justify-content-center"">
                        <div class=""address-img"">
                          <p style=""display:none;""></p>
                          <button type=""button"" class=""btn addressEditbtn"" data-toggle=""modal""");
            BeginWriteAttribute("onclick", " onclick=\"", 1737, "\"", 1781, 3);
            WriteAttributeValue("", 1747, "addEditAddress(", 1747, 15, true);
#nullable restore
#line 48 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
WriteAttributeValue("", 1762, address.AddressId, 1762, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1780, ")", 1780, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-target=\"#EditAddressModal\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a4931451473dba770c6a7601d6139d8d1cdee00e9338", async() => {
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
            WriteLiteral("</button>\r\n                          <button type=\"button\" class=\"btn addressDeletebtn\" data-toggle=\"modal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1956, "\"", 1999, 3);
            WriteAttributeValue("", 1966, "deleteAddress(", 1966, 14, true);
#nullable restore
#line 49 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
WriteAttributeValue("", 1980, address.AddressId, 1980, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1998, ")", 1998, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-target=\"#addressDeleteModal\" >");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a4931451473dba770c6a7601d6139d8d1cdee00e11088", async() => {
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
            WriteLiteral("</button>\r\n                        </div>\r\n                      </td>\r\n                </tr>\r\n");
#nullable restore
#line 53 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"

                i++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("             \r\n\r\n    \r\n                  </tbody>\r\n                </table>\r\n                \r\n\r\n                \r\n");
#nullable restore
#line 64 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
                 if (i == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"text-danger\">You have not added any address yet, You can add new by clicking below button</div>\r\n");
#nullable restore
#line 67 "H:\Bhavin_Tatvasoft_Training\PSD to HTML\Helperland\Helperland\Helperland_integration\Views\CustomerDashboard\customerAddress.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"               

             

                <div class=""addNewAddress"">
                  <button class=""btn"" data-toggle=""modal"" data-target=""#EditAddressModal"" onclick=""addEditAddress(0)"">Add New Address</button>
                </div>


                 <div class=""modal"" id=""EditAddressModal"" tabindex=""-1"" role=""dialog""");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 2856, "\"", 2874, 0);
            EndWriteAttribute();
            WriteLiteral(@" aria-hidden=""true"">

                 </div>

        </div>


        <!-- ---------------------dashboard-AddressdeleteModal part start------------------- -->


      <!-- Modal -->
      <div class=""modal "" id=""addressDeleteModal"" tabindex=""-1"" role=""dialog""");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 3147, "\"", 3165, 0);
            EndWriteAttribute();
            WriteLiteral(" aria-hidden=\"true\">\r\n       \r\n      </div>\r\n\r\n      <!-- ---------------------dashboard-AddressdeleteModal part End------------------- -->\r\n\r\n\r\n\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4931451473dba770c6a7601d6139d8d1cdee00e14462", async() => {
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
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4931451473dba770c6a7601d6139d8d1cdee00e15506", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserAddress>> Html { get; private set; }
    }
}
#pragma warning restore 1591