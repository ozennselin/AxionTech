using Business.Service.Interfaces;
using Core.Models.Entities.ProductPicture;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class ProductPictureService : IProductPictureService
{
    private readonly IProductPictureRepository _productPictureRepository;
    public ProductPictureService(IProductPictureRepository productPictureRepository)
    {
        _productPictureRepository = productPictureRepository;
    }
    public void Create(CreateProductPictureRequestModel request)
    {
        var newProductPicture = new ProductPicture
        {
            //ProductId = request.ProductId,
            //Url = request.Url,
            //IsMain = request.IsMain,
            //DisplayOrder = request.DisplayOrder
        };
        _productPictureRepository.Add(newProductPicture);
    }

    public void Delete(DeleteProductPictureRequestModel request)
    {
       var pictureToDelete = _productPictureRepository.GetById(request.Id);
        if (pictureToDelete == null)
         {
             throw new Exception("Product picture not found.");
        }
        _productPictureRepository.Delete(pictureToDelete);
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
}
