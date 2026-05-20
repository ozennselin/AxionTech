using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AxionTech.WEB.TagHelpers;


[HtmlTargetElement("ax-button")]
public class ButtonTagHelper : TagHelper
{
    public string Name { get; set; }
    public string Class { get; set; } = "btn";
    public string Href { get; set; }
    public bool Visible { get; set; }
    public string Value { get; set; }
    public bool Yetki { get; set; }


    public override void Process(TagHelperContext context, TagHelperOutput output)
    {

        //eğer Session,Cookie  ile  login olan kullanıcı yetkisi varsa false gelicek ve buton gözükecek, yoksa true gelicek ve buton gözükmeyecek
        if (Yetki == false)
        {
            Visible = true;//yetki olmadığı için gösterme
        }
        if (Visible)
        {
            output.Attributes.SetAttribute("visible", Visible);
            output.SuppressOutput();
            return;
        }
        output.TagName = "a";
        output.Attributes.SetAttribute("name", Name);
        if (Name == "detail")
        {
            Class = "btn btn-block btn-primary btn-sm";
        }
        else if (Name == "delete")
        {
            Class = "btn btn-block btn-danger btn-sm";
        }
        else if (Name == "update")
        {
            Class = "btn btn-block btn-warning btn-sm";
        }
        output.Attributes.SetAttribute("class", Class);


        base.Process(context, output);
    }


}
