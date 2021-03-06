#pragma checksum "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ff51b2c56d3679c24e5248a06087e75a63e85ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Schedule_TeacherSchedule), @"mvc.1.0.view", @"/Views/Schedule/TeacherSchedule.cshtml")]
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
#line 1 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\_ViewImports.cshtml"
using App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\_ViewImports.cshtml"
using App.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\_ViewImports.cshtml"
using App.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\_ViewImports.cshtml"
using App.Models.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ff51b2c56d3679c24e5248a06087e75a63e85ff", @"/Views/Schedule/TeacherSchedule.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5dbe54fb5424fb3930f43d51cd880a391d5e2eba", @"/Views/_ViewImports.cshtml")]
    public class Views_Schedule_TeacherSchedule : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ScheduleListViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Schedule", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeSchedule", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
  
    ViewData["Title"] = "스케쥴 조회";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
 if (User.Identity.IsAuthenticated && User.IsInRole("manager"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <div>\r\n        <h3>");
#nullable restore
#line 11 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
       Write(Model[0].Teacher.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" 선생님 스케쥴</h3>\r\n        <p class=\"align-middle text-center\">핸드폰 번호 : ");
#nullable restore
#line 12 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
                                                Write(Model[0].Teacher.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"align-middle text-center\">전공 악기 : ");
#nullable restore
#line 13 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
                                               Write(Model[0].Teacher.Ins);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
    </div>
    
    <br />
    <table class=""table"">
        <thead>
            <tr>
                <th class=""align-middle text-center"">회원</th>
                <th class=""align-middle text-center"">레슨 시간</th>
                <th class=""align-middle text-center"">핸드폰 번호</th>
                <th class=""align-middle text-center"">레슨 상태</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 27 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
             foreach (ScheduleListViewModel m in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"align-middle text-center\">");
#nullable restore
#line 30 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
                                                    Write(m.Student.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle text-center\">");
#nullable restore
#line 31 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
                                                    Write(m.Schedule.ScheduleTime.ToString("MM-dd  오후 hh시"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle text-center\">");
#nullable restore
#line 32 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
                                                    Write(m.Student.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle text-center\">\r\n");
#nullable restore
#line 34 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
                         if (m.Schedule.LessonStatus == Schedule.Status.Waiting)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ff51b2c56d3679c24e5248a06087e75a63e85ff8062", async() => {
                WriteLiteral("변경");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
                                                                                                            WriteLiteral(m.Schedule.StudentId);

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
            WriteLiteral("\r\n                            <!-- 개인 스케쥴 페이지로 가서 조정한다. -->\r\n");
#nullable restore
#line 38 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"btn btn-danger\">완료</div>\r\n");
#nullable restore
#line 42 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 46 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
#nullable restore
#line 50 "C:\Users\hiper\Desktop\C#\RubySound\App\App\Views\Schedule\TeacherSchedule.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ScheduleListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
