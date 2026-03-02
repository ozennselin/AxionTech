using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }
}
