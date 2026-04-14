using Core.Enums;
using Core.Models.Entities.Role;

namespace Business.Service.Interfaces;

public interface IRoleService
{
    ResponseMessageEnum Create(CreateRoleRequestModel request);
    ResponseMessageEnum Update(UpdateRoleRequestModel request);
    ResponseMessageEnum Delete(DeleteRoleRequestModel request);

    List<RoleResponseModel> List();
    RoleResponseModel? GetById(int id);
}