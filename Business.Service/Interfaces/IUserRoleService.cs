using Core.Models.Entities.ProductPicture;
using Core.Models.Entities.UserRole;
using Data.Infrastructure.Entities;

namespace Business.Service.Interfaces;

public interface IUserRoleService
{
    void Create(CreateUserRoleRequestModel request);
    void Update(UpdateUserRoleRequestModel request);
    void Delete(DeleteUserRoleRequestModel request);
    List<UserRoleResponseModel> GetByUserId(int userId);
    List<UserRoleResponseModel> GetByRoleId(int roleId);

}
