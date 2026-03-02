using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }
}
