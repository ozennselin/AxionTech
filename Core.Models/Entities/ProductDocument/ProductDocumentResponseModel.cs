namespace Core.Models.Entities.ProductDocument;

public class ProductDocumentResponseModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Url { get; set; }=string.Empty;
    public string FileName {  get; set; }=string.Empty;
    public string FileType {  get; set; }=string.Empty;
}
