using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class ProductPriceRepository : Repository<ProductPrice>, IProductPriceRepository
{
    public ProductPriceRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }

    public List<ProductPrice> GetByProductId(int productId)
    {
        return _dbSet.Where(pp => pp.ProductId == productId).ToList();
    }

}
