using Business.Service.Interfaces;
using Core.Dtos.Entities.Product;
using Core.Enums;
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
    private readonly IProductPriceRepository _productPriceRepository;
    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IProductDocumentRepository productDocumentRepository, IProductPictureRepository productPictureRepository, IProductPriceRepository productPriceRepository)
    {
        //bu method construction(yapıcı) methodtur.Ağağısındaki yapı DI(dependency injection) olarak isimlendirilir.    
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _productDocumentRepository = productDocumentRepository;
        _productPictureRepository = productPictureRepository;
        _productPriceRepository = productPriceRepository;
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
        response.Picture = _productPictureRepository.Any(k => k.ProductId == Id) ? _productPictureRepository.GetEntityQuery(k => k.IsMain == true && k.ProductId == Id).Url : "";
        //?? devam edilecek, expression tanımı gerekli Repoda=> Expression tanımı yapıldı
        response.Price = _productPriceRepository.Any(k => k.ProductId == Id) ? _productPriceRepository.GetEntityQuery(k => k.IsActive && k.ProductId == Id).Price : 0;

        return response;
    }

    public List<ProductResponseModel> List()
    {
        //Open, Close=> her request kendisinden önce giden requestin bitmesini bekler

        var productList = _productRepository.GetAll().ToList();

        return productList.Select(p =>
        {
            var categoryName = _categoryRepository.GetById(p.CategoryId);

            return new ProductResponseModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId,
                CategoryName = categoryName.Name,
                Picture = _productPictureRepository.Any(k => k.ProductId == p.Id) ? _productPictureRepository.GetEntityQuery(k => k.IsMain == true && k.ProductId == p.Id).Url : "",
                Price = _productPriceRepository.Any(k => k.ProductId == p.Id) ? _productPriceRepository.GetEntityQuery(k => k.IsActive && k.ProductId == p.Id).Price : 0
            };

        }).ToList();
    }

    public ResponseMessageEnum Update(UpdateProductRequestModel request)
    {
        try
        {
            var getProduct = _productRepository.GetById(request.Id);

            if (getProduct == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            getProduct.Name = request.Name;
            getProduct.Description = request.Description;
            getProduct.CategoryId = _categoryRepository.GetEntityQuery(k => k.Name == request.CategoryName).Id;
            getProduct.UpdateDate = DateTime.Now;
            getProduct.UpdaterId = 1;

            _productRepository.Update(getProduct);
            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception ex)
        {
            //log işlemi yapılabilir. Sadece hata mesajını döndürüyoruz.
            //var log=ex.Message;//zaman,Class,method//örnek
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }

}
