using Core.Enums;
using Core.Models.Entities.MenuRole;

namespace Business.Service.Interfaces;

public interface IMenuRoleService
{
    ResponseMessageEnum Create(List<CreateMenuRoleRequestModel> request);
    List<MenuRoleResponseModel> List();
    List<MenuRoleResponseModel> GetByRoleId(int roleId);
    ResponseMessageEnum Update(UpdateMenuRoleRequestModel request);
}