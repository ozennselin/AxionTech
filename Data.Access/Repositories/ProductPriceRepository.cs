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

}
