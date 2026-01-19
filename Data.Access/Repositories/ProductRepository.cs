using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }

    public List<Product> ProductListWithCategory()
    {
        return _dbSet.ToList();
    }
}
