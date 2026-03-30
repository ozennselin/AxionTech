namespace Core.Models.Entities.ProductPicture;

public class ProductPictureResponseModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Url { get; set; } = string.Empty;
    public bool IsMain { get; set; }
    public int DisplayOrder { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OrjinalName { get; set; } = string.Empty;
}
