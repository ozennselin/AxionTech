using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }

    //public void Delete(Cart cart)
    //{
    //    _dbSet.Remove(cart);
    //    _axionTechDB.SaveChanges();
    //}

    //public void Update(Cart cart)
    //{
    //    _dbSet.Update(cart);
    //    _axionTechDB.SaveChanges();
    //}
}
