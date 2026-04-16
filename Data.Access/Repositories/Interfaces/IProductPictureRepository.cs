using Data.Infrastructure.Entities;

namespace Data.Access.Repositories.Interfaces;

public interface IProductPictureRepository:IRepository<ProductPicture>
{
    List<ProductPicture> GetByProductId(int productId);
    int PictureCountByProductId(int productId);
    ProductPicture GetMainPictureByProductId(int productId);
}
