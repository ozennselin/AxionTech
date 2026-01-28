using Core.Models.Entities.ProductPicture;

namespace Business.Service.Interfaces;

public interface IProductPictureService
{
    void Create(CreateProductPictureRequestModel request);
    void Update(UpdateProductPictureRequestModel request);
    void Delete(DeleteProductPictureRequestModel request);
    List<ProductPictureResponseModel> GetByProductId(int productId);
}
