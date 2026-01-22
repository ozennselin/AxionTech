using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class ProductPictureRepository : Repository<ProductPicture>, IProductPictureRepository
{
    public ProductPictureRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }
}
