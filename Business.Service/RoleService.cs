using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Role;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public ResponseMessageEnum Create(CreateRoleRequestModel request)
    {
        try
        {
            Role role = new Role();

            role.Name = request.Name;
            role.Description = request.Description;
            role.IsActive = request.IsActive;

            _roleRepository.Add(role);

            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }

    public ResponseMessageEnum Delete(DeleteRoleRequestModel request)
    {
        try
        {
            var getRole = _roleRepository.GetById(request.Id);

            if (getRole == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            getRole.IsActive = false;
            _roleRepository.Update(getRole);

            return ResponseMessageEnum.Success;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.DeleteErrorWithMessage;
        }
    }

    public RoleResponseModel? GetById(int id)
    {
        var getRole = _roleRepository.GetById(id);

        if (getRole == null)
            return null;

        return new RoleResponseModel
        {
            Id = getRole.Id,
            Name = getRole.Name,
            Description = getRole.Description,
            IsActive = getRole.IsActive,
            UserCount = getRole.UserRoles.Count
        };
    }

    public List<RoleResponseModel> List()
    {
        var roles = _roleRepository
            .GetAll()
            .Where(x => x.IsActive == true)
            .ToList();

        return roles.Select(x => new RoleResponseModel
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            IsActive = x.IsActive,
            UserCount = x.UserRoles.Count
        }).ToList();
    }

    public ResponseMessageEnum Update(UpdateRoleRequestModel request)
    {
        try
        {
            var getRole = _roleRepository.GetById(request.Id);

            if (getRole == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            getRole.Name = request.Name;
            getRole.Description = request.Description;
            getRole.IsActive = request.IsActive;

            _roleRepository.Update(getRole);

            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }
}