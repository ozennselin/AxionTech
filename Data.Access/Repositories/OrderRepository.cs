using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }

  
}
