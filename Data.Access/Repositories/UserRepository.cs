using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }
}
