using Microsoft.AspNetCore.Razor.TagHelpers;

namespace N31.BlazorServerMVVM.Base;

[HtmlTargetElement("button", Attributes = "command")]
public class CommandTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);
    }
}
