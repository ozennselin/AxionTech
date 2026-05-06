using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Product;

public class CreateProductRequestModel:BaseCreateModel
{
    public int Id {  get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string Message { get; set; } = string.Empty;
}
