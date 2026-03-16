using Data.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Access.Repositories.Interfaces;

public interface IProductPriceRepository:IRepository<ProductPrice>
{
    List<ProductPrice> GetByProductId(int productId);
}
