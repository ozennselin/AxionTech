using Core.Models.Entities.Category;
using Core.Models.Entities.Product;

namespace AxionTech.WEB.Models.Product;

public class ProductListPageViewModel
{
    public List<ProductResponseModel> Products { get; set; } = new();
    public List<CategoryResponseModel> Categories { get; set; } = new();
    public int? SelectedCategoryId { get; set; }
}
