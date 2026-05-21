using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.MenuRole;
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
}