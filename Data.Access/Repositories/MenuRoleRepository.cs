using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class MenuRoleRepository : Repository<MenuRole>, IMenuRoleRepository
{
    public MenuRoleRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }
}
