#pragma checksum "D:\github\sep3\tier1\Pages\Register.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5a8fe4c73d0bc50ed89eaf647ad6b5377328a57"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Assignment.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\github\sep3\tier1\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\github\sep3\tier1\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\github\sep3\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\github\sep3\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\github\sep3\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\github\sep3\tier1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\github\sep3\tier1\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\github\sep3\tier1\_Imports.razor"
using Assignment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\github\sep3\tier1\_Imports.razor"
using Assignment.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\github\sep3\tier1\Pages\Register.razor"
using tier1.Data.Impl;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\github\sep3\tier1\Pages\Register.razor"
using LoginComponent;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\github\sep3\tier1\Pages\Register.razor"
using tier1.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Register")]
    public partial class Register : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 20 "D:\github\sep3\tier1\Pages\Register.razor"
       

    public string username;
    public string password;
    public string message;
    public IUserService userService=new userService();

    

    public void RegisterNewUser()
    {
        userService.RegisterUser(username, password);
        message = "Register succedds!";

    }
    
    
    





#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
