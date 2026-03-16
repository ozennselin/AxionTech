using Data.Infrastructure.Entities;

namespace Data.Access.Repositories.Interfaces;

public interface IProductDocumentRepository:IRepository<ProductDocument>
{
    List<ProductDocument> GetByProductId(int productId);
    void Delete(ProductDocument productDocument);
    void Update(ProductDocument productDocument);
}
