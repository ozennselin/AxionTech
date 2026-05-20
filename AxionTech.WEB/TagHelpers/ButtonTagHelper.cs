using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AxionTech.WEB.TagHelpers;


[HtmlTargetElement("ax-button")]
public class ButtonTagHelper : TagHelper
{
    public string Class { get; set; } = "btn";
    //public string Href { get; set; } = "";
    public string Name { get; set; }
    public bool Visible { get; set; } 


    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        //eğer Session,Cookie  ile  login olan kullanıcı yetkisi varsa false gelicek ve buton gözükecek, yoksa true gelicek ve buton gözükmeyecek
        //if (Visible)
        //{
        //    output.SuppressOutput();
        //    return;
        //}
        output.TagName = "button";
        Class = "btn btn-primary";
        Name = "Kaydet";
        output.Attributes.SetAttribute("class", Class);
        output.Attributes.SetAttribute("nama", Name);
        //output.Attributes.SetAttribute("href", Href);


        base.Process(context, output);
    }


}
