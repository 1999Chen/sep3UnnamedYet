#pragma checksum "D:\github\sep3\tier1\Pages\ManagePersonalInfo.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f911e7c65a4b42d2d9e2059381ca503869ce456e"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/ManagePersonalInfo")]
    public partial class ManagePersonalInfo : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "form-group");
            __builder.AddMarkupContent(2, "\r\n                  ");
            __builder.AddMarkupContent(3, "<label>Name:</label>\r\n                  ");
            __builder.OpenElement(4, "input");
            __builder.AddAttribute(5, "type", "text");
            __builder.AddAttribute(6, "placeholder", "user name");
            __builder.AddAttribute(7, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 5 "D:\github\sep3\tier1\Pages\ManagePersonalInfo.razor"
                                                                          name

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => name = __value, name));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n              ");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n        ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "form-group");
            __builder.AddMarkupContent(13, "\r\n            ");
            __builder.AddMarkupContent(14, "<label>Sex:</label>\r\n            ");
            __builder.OpenElement(15, "input");
            __builder.AddAttribute(16, "type", "text");
            __builder.AddAttribute(17, "placeholder", "user name");
            __builder.AddAttribute(18, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 9 "D:\github\sep3\tier1\Pages\ManagePersonalInfo.razor"
                                                                    sex

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(19, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => sex = __value, sex));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n        ");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "form-group");
            __builder.AddMarkupContent(24, "\r\n            ");
            __builder.AddMarkupContent(25, "<label>Age:</label>\r\n            ");
            __builder.OpenElement(26, "input");
            __builder.AddAttribute(27, "type", "text");
            __builder.AddAttribute(28, "placeholder", "user name");
            __builder.AddAttribute(29, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 13 "D:\github\sep3\tier1\Pages\ManagePersonalInfo.razor"
                                                                    age

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(30, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => age = __value, age));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n        ");
            __builder.OpenElement(33, "div");
            __builder.AddAttribute(34, "class", "form-group");
            __builder.AddMarkupContent(35, "\r\n            ");
            __builder.AddMarkupContent(36, "<label>Hometown:</label>\r\n            ");
            __builder.OpenElement(37, "input");
            __builder.AddAttribute(38, "type", "text");
            __builder.AddAttribute(39, "placeholder", "user name");
            __builder.AddAttribute(40, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 17 "D:\github\sep3\tier1\Pages\ManagePersonalInfo.razor"
                                                                    hometown

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(41, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => hometown = __value, hometown));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n        ");
            __builder.OpenElement(44, "div");
            __builder.AddAttribute(45, "class", "form-group");
            __builder.AddMarkupContent(46, "\r\n            ");
            __builder.AddMarkupContent(47, "<label>Major:</label>\r\n            ");
            __builder.OpenElement(48, "input");
            __builder.AddAttribute(49, "type", "text");
            __builder.AddAttribute(50, "placeholder", "user name");
            __builder.AddAttribute(51, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 21 "D:\github\sep3\tier1\Pages\ManagePersonalInfo.razor"
                                                                    major

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(52, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => major = __value, major));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n        ");
            __builder.OpenElement(55, "div");
            __builder.AddAttribute(56, "class", "form-group");
            __builder.AddMarkupContent(57, "\r\n            ");
            __builder.AddMarkupContent(58, "<label>Friends:</label>\r\n            ");
            __builder.OpenElement(59, "input");
            __builder.AddAttribute(60, "type", "text");
            __builder.AddAttribute(61, "placeholder", "user name");
            __builder.AddAttribute(62, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 25 "D:\github\sep3\tier1\Pages\ManagePersonalInfo.razor"
                                                                    friends

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(63, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => friends = __value, friends));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n        ");
            __builder.OpenElement(66, "div");
            __builder.AddAttribute(67, "class", "form-group");
            __builder.AddMarkupContent(68, "\r\n            ");
            __builder.OpenElement(69, "button");
            __builder.AddAttribute(70, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "D:\github\sep3\tier1\Pages\ManagePersonalInfo.razor"
                              update

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(71, "text", "Update");
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\r\n        ");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 31 "D:\github\sep3\tier1\Pages\ManagePersonalInfo.razor"
       
    public string name;
    public string sex;
    public int age;
    public string hometown;
    public string major;
    public int friends;


    public void update()
    {
        
    }









#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591