using Data.Infrastructure.Entities;

namespace Data.Access.Repositories.Interfaces;

public interface IOrderRepository:IRepository<Order>
{
    void Update(Order order);
    void Delete(Order order);
}
