using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class MenuRepository : Repository<Menu>,IMenuRepository
{
    public MenuRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }
}
