#pragma checksum "D:\c#\sep3\tier1\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f0ac6d3876e03f6827e9f942025ec799e6cb783"
// <auto-generated/>
#pragma warning disable 1591
namespace Assignment.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\c#\sep3\tier1\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\c#\sep3\tier1\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\c#\sep3\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\c#\sep3\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\c#\sep3\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\c#\sep3\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\c#\sep3\tier1\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\c#\sep3\tier1\_Imports.razor"
using Assignment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\c#\sep3\tier1\_Imports.razor"
using Assignment.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(2, "<h1>Welcome to the system!</h1>");
            }
            ));
            __builder.AddAttribute(3, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(4, "h1");
                __builder2.AddContent(5, "Hello ");
                __builder2.AddContent(6, 
#nullable restore
#line 4 "D:\c#\sep3\tier1\Pages\Index.razor"
                       context.User.Identity.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
