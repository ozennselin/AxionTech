using Data.Infrastructure.Entities;

namespace Data.Access.Repositories.Interfaces;

public interface IProductPictureRepository:IRepository<ProductPicture>
{
    List<ProductPicture> GetByProductId(int productId);
    void Delete(ProductPicture productPicture);
    void Update(ProductPicture productPicture);
}
