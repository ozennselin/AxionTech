using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.ProductPicture;

public class CreateProductPictureRequestModel:BaseCreateModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string OriginalFileName { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long FileSize { get; set; }
}
