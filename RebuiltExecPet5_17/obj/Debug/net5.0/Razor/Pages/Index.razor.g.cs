#pragma checksum "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5623a5225b68eace1cdf91e66e5c8c88d16d0fc8"
// <auto-generated/>
#pragma warning disable 1591
namespace RebuiltExecPet5_17.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\_Imports.razor"
using RebuiltExecPet5_17;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\_Imports.razor"
using RebuiltExecPet5_17.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : IndexBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Quotes List</h1>");
#nullable restore
#line 7 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\Pages\Index.razor"
 if (Quotes == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p><em>Loading...</em></p>");
#nullable restore
#line 10 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\Pages\Index.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "table");
            __builder.AddAttribute(3, "class", "table");
            __builder.AddMarkupContent(4, "<thead><tr><th>Name</th>\r\n                <th>Email</th>\r\n                <th>Phone Number</th>\r\n                <th>Cell Number</th></tr></thead>\r\n        ");
            __builder.OpenElement(5, "tbody");
#nullable restore
#line 23 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\Pages\Index.razor"
             foreach (var q in Quotes)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(6, "tr");
            __builder.OpenElement(7, "td");
#nullable restore
#line 26 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\Pages\Index.razor"
__builder.AddContent(8, q.petOwner.FirstName + " " +@q.petOwner.LastName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n                    ");
            __builder.OpenElement(10, "td");
#nullable restore
#line 27 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\Pages\Index.razor"
__builder.AddContent(11, q.petOwner.Email);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n                    ");
            __builder.OpenElement(13, "td");
#nullable restore
#line 28 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\Pages\Index.razor"
__builder.AddContent(14, q.petOwner.PhoneNumber);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                    ");
            __builder.OpenElement(16, "td");
#nullable restore
#line 29 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\Pages\Index.razor"
__builder.AddContent(17, q.petOwner.CellNumber);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                    ");
            __builder.AddMarkupContent(19, "<td><a href=\"#\" class=\"btn btn-primary m-1\">View</a></td>\r\n                    ");
            __builder.AddMarkupContent(20, "<td><a href=\"#\" class=\"btn btn-primary m-1\">Edit</a></td>\r\n                    ");
            __builder.AddMarkupContent(21, "<td><a href=\"#\" class=\"btn btn-danger m-1\">Delete</a></td>");
            __builder.CloseElement();
#nullable restore
#line 40 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\Pages\Index.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n    <hr>");
            __builder.AddMarkupContent(23, "<a href=\"components/quotecomponent\" class=\"btn btn-primary m-1\">Create a Quote</a>");
#nullable restore
#line 46 "C:\Users\dablu\source\repos\RebuiltExecPet\RebuiltExecPet\RebuiltExecPet5_17\Pages\Index.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
