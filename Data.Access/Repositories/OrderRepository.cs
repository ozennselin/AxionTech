using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }

    public void Delete(Order order)
    {
        _dbSet.Remove(order);
        _axionTechDB.SaveChanges();
    }

    public void Update(Order order)
    {
        _dbSet.Update(order);
        _axionTechDB.SaveChanges();
    }
}
