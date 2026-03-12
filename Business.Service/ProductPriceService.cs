using Business.Service.Interfaces;
using Core.Models.Entities.ProductDocument;
using Core.Models.Entities.ProductPrice;
using Data.Access.Repositories.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Business.Service;

public class ProductPriceService : IProductPriceService
{
    private readonly IProductPriceRepository _productPriceRepository;

    public ProductPriceService(IProductPriceRepository productPriceRepository)
    {
        _productPriceRepository = productPriceRepository;
    }

    public void Create(CreateProductPriceRequestModel request)
    {
        throw new NotImplementedException();
    }

    public void Delete(DeleteProductPriceRequestModel request)
    {
        throw new NotImplementedException();
    }

    public ProductPriceResponseModel? GetByProductId(int productId)
    {
        var getPrice = _productPriceRepository.GetByProductId(productId);
        if (getPrice==null)
        {
            return null;
        }
          return new ProductPriceResponseModel
          {
              Id = getPrice.Id,
              ProductId = getPrice.ProductId,
              Price = getPrice.Price,
              Description = getPrice.Description
          };
    }

    public void Update(UpdateProductPriceRequestModel request)
    {
        throw new NotImplementedException();
    }
}
