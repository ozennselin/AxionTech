using Business.Service.Interfaces;
using Data.Access.Repositories.Interfaces;

namespace Business.Service;

public class ProductService : IProductService
{
   

    public ProductService(IProductRepository productrepository)
    {
        _productrepository = productrepository;
    }

    public void Create(CreateProductRequestModel request)
    {
        _productrepository.Add();
    }

    public void Delete(DeleteProductRequestModel request)
    {
        throw new NotImplementedException();
    }

    public List<ProductResponseModel> List()
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateProductRequestModel request)
    {
        throw new NotImplementedException();
    }
}
