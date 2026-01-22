using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class CustomerTypeRepository : Repository<CustomerType>, ICustomerTypeRepository
{
    public CustomerTypeRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }
}
