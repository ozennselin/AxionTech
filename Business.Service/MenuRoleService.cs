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
            foreach(var item in request) 
            {
                bool isExist = _menuRoleRepository.Any(x => x.MenuId == item.MenuId && x.RoleId == item.RoleId);
                if (isExist)
                {
                    return ResponseMessageEnum.Exist;
                }
            }
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

    ///
    public List<MenuRoleResponseModel> List()
    {
        var menuList = _menuRoleRepository.GetAll();//40*25=1000

        return menuList.Select(x => new MenuRoleResponseModel
        {
            RoleId = x.RoleId,
            MenuId = x.MenuId,
            RoleName= "role adı",
            MenuName = "menu adı",
            IsActive = x.IsActive
        }).ToList();
    }

    /// <summary>
    /// MenuRole list with roleId List
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public List<MenuRoleResponseModel> List(int roleId)
    {
        var menuList = _menuRoleRepository.GetAllQuery(k=>k.RoleId==roleId);//4*10=40

        return menuList.Select(x => new MenuRoleResponseModel
        {
            RoleId = x.RoleId,
            MenuId = x.MenuId,
            RoleName = "role adı",
            MenuName = "menu adı",
            IsActive = x.IsActive
        }).ToList();
    }
    public List<MenuRoleResponseModel> GetByRoleId(int roleId)
    {
        var menuRoleList = _menuRoleRepository
            .GetAll()
            .Where(x => x.RoleId == roleId)
            .ToList();

        return menuRoleList.Select(x => new MenuRoleResponseModel
        {
            RoleId = x.RoleId,
            MenuId = x.MenuId,
            RoleName = "role adı",
            MenuName = "menu adı",
            IsActive = x.IsActive
        }).ToList();
    }
    public ResponseMessageEnum Update(UpdateMenuRoleRequestModel request)
    {
        try
        {
            var oldMenuRoles = _menuRoleRepository
                .GetAll()
                .Where(x => x.RoleId == request.RoleId)
                .ToList();

            foreach (var item in oldMenuRoles)
            {
                item.IsActive = request.MenuIds.Contains(item.MenuId);
            }

            var oldMenuIds = oldMenuRoles
                .Select(x => x.MenuId)
                .ToList();

            var newMenuRoles = request.MenuIds
                .Where(menuId => !oldMenuIds.Contains(menuId))
                .Select(menuId => new MenuRole
                {
                    RoleId = request.RoleId,
                    MenuId = menuId,
                    IsActive = true
                })
                .ToList();

            _menuRoleRepository.UpdateRange(oldMenuRoles);

            if (newMenuRoles.Any())
            {
                _menuRoleRepository.AddRange(newMenuRoles);
            }

            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateError;
        }
    }

}