using Core.Enums;
using Core.Models.Entities.Product;

namespace Business.Service.Interfaces;

 public interface IProductService
{
    void Create(CreateProductRequestModel request);
    (UpdateProductRequestModel model, ResponseMessageEnum messge) Update(UpdateProductRequestModel request);
    void Delete(DeleteProductRequestModel request);
    List<ProductResponseModel> List();
    ProductResponseModel GetById(int Id);
}
