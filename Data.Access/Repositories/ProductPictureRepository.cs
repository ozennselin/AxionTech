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
    public void Delete(ProductPicture productPicture)
    {
        _dbSet.Remove(productPicture);
        _axionTechDB.SaveChanges();
    }
    public void Update(ProductPicture productPicture)
    {
        _dbSet.Update(productPicture);
        _axionTechDB.SaveChanges();
    }
}
