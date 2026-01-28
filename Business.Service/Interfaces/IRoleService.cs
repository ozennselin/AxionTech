using Core.Models.Entities.Role;

namespace Business.Service.Interfaces;

public interface IRoleService
{
    void Create(CreateRoleRequestModel request);
    void Update(UpdateRoleRequestModel request);
    void Delete(DeleteRoleRequestModel request);
    List<RoleResponseModel> List();
    RoleResponseModel? GetById(int id);
}
