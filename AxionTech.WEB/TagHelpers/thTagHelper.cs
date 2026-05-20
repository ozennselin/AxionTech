using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AxionTech.WEB.TagHelpers;

public class thTagHelper:TagHelper
{

    public bool  Visible { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);
    }
}
