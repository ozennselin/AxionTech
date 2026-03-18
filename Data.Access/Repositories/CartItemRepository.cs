using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class CartItemRepository : Repository<CartItem>, ICartItemRepository
{
    public CartItemRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }

    public void Delete(CartItem cartItem)
    {
        _dbSet.Remove(cartItem);
        _axionTechDB.SaveChanges();
    }

    public void Update(CartItem cartItem)
    {
       _dbSet.Update(cartItem);
        _axionTechDB.SaveChanges();
    }
}
