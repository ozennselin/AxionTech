using Data.Infrastructure.Entities;

namespace Data.Access.Repositories.Interfaces;

public interface IOrderItemRepository:IRepository<OrderItem>
{
   void Delete(OrderItem orderItem);
    void Update(OrderItem orderItem);
}
