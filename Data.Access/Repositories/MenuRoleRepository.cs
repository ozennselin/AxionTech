using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

internal class MenuRoleRepository : Repository<MenuRole>, IMenuRoleRepository
{
    public MenuRoleRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }
}
