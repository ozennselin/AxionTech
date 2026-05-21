using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Menu;
using Core.Models.Entities.MenuRole;
using Data.Access.Repositories;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class MenuRoleService : IMenuRoleService
{
    private readonly IMenuRoleRepository _menuRoleRepository;

    public MenuRoleService(IMenuRoleRepository menuRoleRepository)
    {
        _menuRoleRepository = menuRoleRepository;
    }

    public ResponseMessageEnum Create(List<CreateMenuRoleRequestModel> request)
    {
        try
        {
            var menuRoleList = request.Select(x => new MenuRole
            {
                RoleId = x.RoleId,
                MenuId = x.MenuId,
                IsActive = true
            }).ToList();

            _menuRoleRepository.AddRange(menuRoleList);

            return ResponseMessageEnum.Success;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.Error;
        }
    }

    public List<MenuRoleResponseModel> List()
    {
        var menuList = _menuRoleRepository.GetAll();

        return menuList.Select(x => new MenuRoleResponseModel
        {
            RoleId = x.RoleId,
            MenuId = x.MenuId,
            RoleName= "role adı",
            MenuName = "menu adı",
            IsActive = x.IsActive
        }).ToList();
    }

}