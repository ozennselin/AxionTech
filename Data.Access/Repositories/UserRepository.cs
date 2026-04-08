using Core.Dtos.Entities.User;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }

    public UserLoginDto Login(UserLoginDto request)
    {
        var list= _dbSet.FirstOrDefault(u => u.UserName == request.UserName && u.PasswordHash== request.Password);  
        if (list != null)
        {
            return new UserLoginDto
            {
                UserName = list.UserName,
                Password = list.PasswordHash
            };
        }
        return null;
    }
}
