using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.ProductPicture;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;
using System.Linq;

namespace Business.Service;

public class ProductPictureService : IProductPictureService
{
    private readonly IProductPictureRepository _productPictureRepository;
    public ProductPictureService(IProductPictureRepository productPictureRepository)
    {
        _productPictureRepository = productPictureRepository;
    }
    public ResponseMessageEnum Create(CreateProductPictureRequestModel request)
    {
        try
        {
            var isAny = _productPictureRepository.GetAll()
                    .Any(x => x.ProductId == request.ProductId && x.OrjinalName == request.OrjinalName);

            if (isAny)
            {
                return ResponseMessageEnum.Error; 
            }
            var newProductPicture = new ProductPicture
            {
                ProductId = request.ProductId,
                Url = request.Url,
                IsMain = request.IsMain,
                DisplayOrder = request.DisplayOrder,
                Name = request.Name,
                OrjinalName = request.OrjinalName,
                CreateDate=DateTime.Now,
                CreatorId=1
            };
            _productPictureRepository.Add(newProductPicture);
            return ResponseMessageEnum.Success;
        }
        catch (Exception)
        {

            return ResponseMessageEnum.Error;
        }
    }

    public ResponseMessageEnum Delete(DeleteProductPictureRequestModel request)
    {
       var pictureToDelete = _productPictureRepository.GetById(request.Id);
        if (pictureToDelete == null)
         {
             return ResponseMessageEnum.NotExist;
        }
       _productPictureRepository.Delete(pictureToDelete);
        return ResponseMessageEnum.Success;
    }

    public List<ProductPictureResponseModel> GetByProductId(int productId)
    {
        var pictures = _productPictureRepository.GetByProductId(productId);
        return pictures.Select(p => new ProductPictureResponseModel
        {
            Id = p.Id,
            ProductId = p.ProductId,
            Url = p.Url,
            IsMain = p.IsMain,
            DisplayOrder = p.DisplayOrder
        }).ToList();
    }

    public void Update(UpdateProductPictureRequestModel request)
    {
        var pictureToUpdate = _productPictureRepository.GetById(request.Id);
        if (pictureToUpdate == null)
        {
            throw new Exception("Product picture not found.");
        }
        pictureToUpdate.ProductId = request.ProductId;
        pictureToUpdate.Url = request.Url;
        pictureToUpdate.IsMain = request.IsMain;
        pictureToUpdate.DisplayOrder = request.DisplayOrder;
        _productPictureRepository.Update(pictureToUpdate);
    }

    public List<ProductPictureResponseModel> List()
    {
        var list = _productPictureRepository.GetAll().ToList();
      
        return list.Select(p => new ProductPictureResponseModel
            {
                Id = p.Id,
                ProductId = p.ProductId,
                Url = p.Url,
                IsMain = p.IsMain,
                DisplayOrder = p.DisplayOrder,
                Name = p.Name,
                OrjinalName = p.OrjinalName
        }).ToList();
    }

    public ProductPictureResponseModel GetById(int id)
    {
        var result = _productPictureRepository.GetById(id);

        return new ProductPictureResponseModel
        {
            Id = result.Id,
            ProductId = result.ProductId,
            Url = result.Url,
            IsMain = result.IsMain,
            DisplayOrder = result.DisplayOrder,
            Name = result.Name,
            OrjinalName = result.OrjinalName
        };

    }
}
