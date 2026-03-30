using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.ProductPicture;

public class CreateProductPictureRequestModel:BaseCreateModel
{
    public int ProductId { get; set; }
    public string Url { get; set; } = string.Empty;
    public bool IsMain { get; set; }
    public int DisplayOrder { get; set; }
    public string OrjinalName { get; set; }=string.Empty;
    public string Name { get; set; } = string.Empty;

}
