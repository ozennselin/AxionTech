using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AxionTech.WEB.TagHelpers;

[HtmlTargetElement("ax-button")]
public class ButtonTagHelper : TagHelper
{
    public string Type { get; set; } = "submit";
    public string Class { get; set; } // Varsayılan boş bıraktık, aşağıda dinamik dolduracağız
    public string Name { get; set; }
    public bool Visible { get; set; } = true;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (!Visible)
        {
            output.SuppressOutput();
            return;
        }

        output.TagName = "button";
        output.Attributes.SetAttribute("type", Type);

        if (!string.IsNullOrEmpty(Name))
        {
            output.Attributes.SetAttribute("name", Name);
        }

        // Butonun arasındaki yazıyı (Örn: "Kaydet", "Delete") alıyoruz
        var content = await output.GetChildContentAsync();
        string buttonText = content.GetContent().Trim();
        output.Content.SetHtmlContent(buttonText);

        // Eğer dışarıdan özel bir Class ezilmediyse, isme veya içeriğe göre rengi belirle
        if (string.IsNullOrEmpty(Class))
        {
            // Karşılaştırmayı küçük/büyük harfe duyarsız yapıyoruz (Örn: "kaydet", "Kaydet", "KAYDET" hepsi uysun)
            if (buttonText.Equals("kaydet", StringComparison.OrdinalIgnoreCase) ||
                (Name != null && Name.Equals("kaydet", StringComparison.OrdinalIgnoreCase)))
            {
                Class = "btn btn-success";
            }
            else if (buttonText.Equals("delete", StringComparison.OrdinalIgnoreCase) ||
                     (Name != null && Name.Equals("delete", StringComparison.OrdinalIgnoreCase)))
            {
                Class = "btn btn-danger";
            }
            else if (buttonText.Equals("update", StringComparison.OrdinalIgnoreCase) ||
                     (Name != null && Name.Equals("update", StringComparison.OrdinalIgnoreCase)))
            {
                Class = "btn btn-warning";
            }
            else
            {
                Class = "btn btn-primary"; // Eşleşme olmazsa varsayılan mavi buton
            }
        }

        // Belirlenen sınıfı attribute olarak ekle
        output.Attributes.SetAttribute("class", Class);
    }
}