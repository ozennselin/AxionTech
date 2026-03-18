using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }

    public void Delete(OrderItem orderItem)
    {
        _dbSet.Remove(orderItem);
        _axionTechDB.SaveChanges();
    }

    public void Update(OrderItem orderItem)
    {
        _dbSet.Update(orderItem);
        _axionTechDB.SaveChanges();
    }
}
