using Business.Service.Interfaces;
using Core.Dtos.Entities.Product;
using Core.Models.Entities.Product;
using Data.Access.Repositories;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductDocumentRepository _productDocumentRepository;
    private readonly IProductPictureRepository _productPictureRepository;
    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IProductDocumentRepository productDocumentRepository, IProductPictureRepository productPictureRepository )
    {
        //bu method construction(yapıcı) methodtur.Ağağısındaki yapı DI(dependency injection) olarak isimlendirilir.    
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _productDocumentRepository = productDocumentRepository;
        _productPictureRepository = productPictureRepository;
    }
    public void Create(CreateProductRequestModel request)
    {
        throw new NotImplementedException();
    }

    public void Delete(DeleteProductRequestModel request)
    {
        throw new NotImplementedException();
    }

    public ProductResponseModel GetById(int Id)
    {
        var getProduct = _productRepository.GetById(Id);
        ProductResponseModel response = new ProductResponseModel();
        response.Id = getProduct.Id;
        response.Name = getProduct.Name;
        response.Description = getProduct.Description;
        response.CategoryId = getProduct.CategoryId;
        response.CategoryName = _categoryRepository.GetById(getProduct.CategoryId).Name;
        response.Picture = _productPictureRepository.GetById(Id).Url;//?? devam edilecek, expresion tanımı gerekli Repoda
        response.Price = 152.55m;

        return response;
    }

    public List<ProductResponseModel> List()
    {
        //Open, Close=> her request kendisinden önce giden requestin bitmesini bekler

        var productList = _productRepository.GetAll().ToList();

        return productList.Select(p=>
        {
            var categoryName = _categoryRepository.GetById(p.CategoryId);

                   return new ProductResponseModel
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Description = p.Description,
                       CategoryId = p.CategoryId,
                       CategoryName = categoryName.Name,
                       Picture = "",//_productPictureRepository.GetById(p.Id).Url,
                       Price = 125
                   };

        }).ToList();
    }

    public void Update(UpdateProductRequestModel request)
    {
        throw new NotImplementedException();
    }

}
