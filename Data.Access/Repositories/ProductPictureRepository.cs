using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class ProductPictureRepository : Repository<ProductPicture>, IProductPictureRepository
{
    public ProductPictureRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }
    public List<ProductPicture> GetByProductId(int productId)
    {
        return _dbSet.Where(pp => pp.ProductId == productId).ToList();
    }

    public int PictureCountByProductId(int productId)
    {
        try
        {
        return _dbSet.Count(pp => pp.ProductId == productId);
        }
        catch (Exception)
        {
            return 0;
        }
    }
}
