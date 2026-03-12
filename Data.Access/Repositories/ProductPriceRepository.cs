using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Access.Repositories;

public class ProductPriceRepository : Repository<ProductPrice>, IProductPriceRepository
{
    public ProductPriceRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }

    public ProductPrice GetByProductId(int productId)
    {
       //return _axionTechDB.ProductPrice.FirstOrDefault(k => k.ProductId == productId);
     return _dbSet.FirstOrDefault(k => k.ProductId == productId && k.IsActive==true);
    }
}
