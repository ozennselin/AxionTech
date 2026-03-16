using Core.Models.Entities.ProductDocument;
using Core.Models.Entities.ProductPrice;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service.Interfaces;

public interface IProductPriceService
{
    void Create(CreateProductPriceRequestModel request);
    void Update(UpdateProductPriceRequestModel request);
    void Delete(DeleteProductPriceRequestModel request);
    ProductPriceResponseModel GetByProductId(int productId);
}
