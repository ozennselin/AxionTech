using Core.Models.Entities.Category;
using Core.Models.Entities.ProductPrice;

namespace Core.Models.Entities.Product;

public class ProductCreateUpdateResponseModel : ProductDetailResponseModel//Solid Close/open Principle=> var olan yapıya yeni özellikler ekleyebiliriz ama var olan yapıyı değiştiremeyiz, ProductDetailResponseModel yapısına yeni özellikler ekleyebiliriz ama var olan yapıyı değiştiremeyiz, bu yüzden ProductCreateUpdateResponseModel adında yeni bir class oluşturup, ProductDetailResponseModel classını miras alarak (inheritance) kullanabiliriz.
{
    public List<CategoryResponseModel> Category { get; set; }
}
