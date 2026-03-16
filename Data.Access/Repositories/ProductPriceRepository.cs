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

    public void Delete(ProductPrice productPrice)
    {
        _dbSet.Remove(productPrice);
        _axionTechDB.SaveChanges();
    }

    public ProductPrice GetByProductId(int productId)
    {
       //return _axionTechDB.ProductPrice.FirstOrDefault(k => k.ProductId == productId);
     return _dbSet.FirstOrDefault(k => k.ProductId == productId && k.IsActive==true);
    }

    public void Update(ProductPrice productPrice)
    {
        _dbSet.Update(productPrice);
        _axionTechDB.SaveChanges();
    }
}
