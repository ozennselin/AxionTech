using Core.Enums;
using Core.Models.Entities.ProductPrice;

namespace Business.Service.Interfaces;

public interface IProductPriceService
{
    ResponseMessageEnum Create(CreateProductPriceRequestModel request);

    ResponseMessageEnum Update(UpdateProductPriceRequestModel request);

    ResponseMessageEnum Delete(DeleteProductPriceRequestModel request);

    List<ProductPriceResponseModel> List();

    ProductPriceResponseModel? GetByProductId(int productId);
}