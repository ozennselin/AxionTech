using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Product;

public class UpdateProductRequestModel:BaseUpdateModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
