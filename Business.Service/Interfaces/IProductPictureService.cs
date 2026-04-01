using Core.Enums;
using Core.Models.Entities.ProductPicture;

namespace Business.Service.Interfaces;

public interface IProductPictureService
{
    ResponseMessageEnum Create(CreateProductPictureRequestModel request);
    void Update(UpdateProductPictureRequestModel request);
    ResponseMessageEnum Delete(DeleteProductPictureRequestModel request);
    List<ProductPictureResponseModel> GetByProductId(int productId);
    List<ProductPictureResponseModel> List();
    ProductPictureResponseModel GetById(int id);
}
