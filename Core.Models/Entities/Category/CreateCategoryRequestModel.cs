using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Category;

public class CreateCategoryRequestModel:BaseCreateModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
