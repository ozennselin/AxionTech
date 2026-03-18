using Business.Service.Interfaces;
using Core.Models.Entities.ProductDocument;
using Core.Models.Entities.ProductPrice;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;
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
        var newPrice = new ProductPrice
        {
            ProductId = request.ProductId,
            Price = request.Price,
            Description = request.Description
        };

        _productPriceRepository.Add(newPrice);
    }

    public void Delete(DeleteProductPriceRequestModel request)
    {
        var priceToDelete = _productPriceRepository.GetById(request.Id);
        if(priceToDelete == null)
        {
            throw new Exception("Price not found");
            
        }
        _productPriceRepository.Delete(priceToDelete);
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
        var priceToUpdate = _productPriceRepository.GetByProductId(request.ProductId);
        if (priceToUpdate == null)
        {
            throw new Exception("Price not found");

        }
        priceToUpdate.ProductId = request.ProductId;
        priceToUpdate.Price = request.Price;
        priceToUpdate.Description = request.Description;
        _productPriceRepository.Update(priceToUpdate);
    }
}
