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
    public ProductService(IProductRepository productRepository)
    {
        //bu method construction(yapıcı) methodtur.Ağağısındaki yapı DI(dependency injection) olarak isimlendirilir.    
        _productRepository = productRepository;
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
        response.Picture = "Boş";
        response.Price = 152.55m;

        return response;
    }

    public List<ProductResponseModel> List()
    {
        return _productRepository.GetAll().Select(p => new
        ProductResponseModel
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            CategoryId = p.CategoryId,
            Picture = "Resim url",
            Price = 125

        }).ToList();
    }

    public void Update(UpdateProductRequestModel request)
    {
        throw new NotImplementedException();
    }

}
