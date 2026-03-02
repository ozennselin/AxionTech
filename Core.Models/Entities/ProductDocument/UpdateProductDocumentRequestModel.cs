using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.ProductDocument;

public class UpdateProductDocumentRequestModel:BaseUpdateModel
{
    public int ProductId { get; set; }
    public string Url { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
}
