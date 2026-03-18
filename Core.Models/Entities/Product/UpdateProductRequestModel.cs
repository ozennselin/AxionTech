using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Product;

public class UpdateProductRequestModel:BaseUpdateModel
{
    public string Name { get; set; } = string.Empty;
    public string CategoryName { get; set; }=string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string Picture { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
