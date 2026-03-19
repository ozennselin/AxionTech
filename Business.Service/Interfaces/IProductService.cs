using Core.Enums;
using Core.Models.Entities.Product;

namespace Business.Service.Interfaces;

 public interface IProductService
{
    void Create(CreateProductRequestModel request);
    ResponseMessageEnum Update(UpdateProductRequestModel request);
    ResponseMessageEnum Delete(DeleteProductRequestModel request);
    List<ProductResponseModel> List();
    ProductResponseModel GetById(int Id);
}
