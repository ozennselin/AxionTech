using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.ProductPicture;
using Core.Models.Entities.ProductPrice;
using Data.Access.Repositories;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class ProductPriceService : IProductPriceService
{
    private readonly IProductPriceRepository _productPriceRepository;

    public ProductPriceService(IProductPriceRepository productPriceRepository)
    {
        _productPriceRepository = productPriceRepository;
    }

    public ResponseMessageEnum Create(CreateProductPictureRequestModel request)
    {
        try
        {
            // AYNI RESİM VAR MI KONTROL
            var isExist = _productPictureRepository
                .GetAll()
                .Any(x => x.ProductId == request.ProductId
                       && x.OrjinalName == request.OrjinalName);

            if (isExist)
            {
                return ResponseMessageEnum.Exist;
            }

            var newProductPicture = new ProductPicture
            {
                ProductId = request.ProductId,
                Url = request.Url,
                IsMain = request.IsMain,
                DisplayOrder = request.DisplayOrder,
                Name = request.Name,
                OrjinalName = request.OrjinalName,
                CreateDate = DateTime.Now,
                CreatorId = 1
            };

            _productPictureRepository.Add(newProductPicture);
            return ResponseMessageEnum.Success;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.Error;
        }
    }

    public ResponseMessageEnum Delete(DeleteProductPriceRequestModel request)
    {
        try
        {
            var priceToDelete = _productPriceRepository.GetById(request.Id);

            if (priceToDelete == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            priceToDelete.IsActive = false;
            _productPriceRepository.Update(priceToDelete);

            return ResponseMessageEnum.Success;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.DeleteErrorWithMessage;
        }
    }

    public ProductPriceResponseModel? GetByProductId(int productId)
    {
        var getPrice = _productPriceRepository.GetAll()
            .FirstOrDefault(x => x.ProductId == productId && x.IsActive);

        if (getPrice == null)
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

    public List<ProductPriceResponseModel> List()
    {
        var prices = _productPriceRepository.GetAll()
            .Where(x => x.IsActive)
            .ToList();

        return prices.Select(x => new ProductPriceResponseModel
        {
            Id = x.Id,
            ProductId = x.ProductId,
            Price = x.Price,
            Description = x.Description
        }).ToList();
    }

    public ResponseMessageEnum Update(UpdateProductPriceRequestModel request)
    {
        try
        {
            var priceToUpdate = _productPriceRepository.GetById(request.Id);

            if (priceToUpdate == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            priceToUpdate.ProductId = request.ProductId;
            priceToUpdate.Price = request.Price;
            priceToUpdate.Description = request.Description;

            _productPriceRepository.Update(priceToUpdate);

            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }
}