using Core.Dtos.Entities.Product;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories.Interfaces;

public interface IProductRepository:IRepository<Product>
{
    //kaydet, update, yani bütün CRUD işlemleri IRepository den gelecek. Eğer CRUd lar dışında yeni method ihtiyacı olursa o zaman o method gövdesi bu Interface eklenir

    List<Product> ProductListWithCategory();
    List<ProductListDto> List();
    bool GetProductWithName(string name);


}
