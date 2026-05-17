using Business.Service.Interfaces;
using Core.Models.Entities.UserRole;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public UserRoleService(
        IUserRoleRepository userRoleRepository,
        IUserRepository userRepository,
        IRoleRepository roleRepository)
    {
        _userRoleRepository = userRoleRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public void Create(CreateUserRoleRequestModel request)
    {
        var isAny = _userRoleRepository.GetAll().Any(x => x.UserId == request.UserId && x.RoleId == request.RoleId);

        if (isAny)
        {
            return;
        }

        var userRole = new UserRole
        {
            UserId = request.UserId,
            RoleId = request.RoleId
        };

        _userRoleRepository.Add(userRole);
    }

    public void Update(UpdateUserRoleRequestModel request)
    {
        var userRole = _userRoleRepository.GetAll().FirstOrDefault(x => x.UserId == request.OldUserId && x.RoleId == request.OldRoleId);

        if (userRole == null)
        {
            return;
        }

        userRole.UserId = request.NewUserId;
        userRole.RoleId = request.NewRoleId;

        _userRoleRepository.Update(userRole);
    }

    public void Delete(DeleteUserRoleRequestModel request)
    {
        var userRole = _userRoleRepository.GetAll().FirstOrDefault(x => x.UserId == request.UserId && x.RoleId == request.RoleId);

        if (userRole == null)
        {
            return;
        }

        _userRoleRepository.Delete(userRole);
    }

    public List<UserRoleResponseModel> GetByUserId(int userId)
    {
        var list = _userRoleRepository.GetAll().Where(x => x.UserId == userId).ToList();

        return list.Select(x =>
        {
            var user = _userRepository.GetById(x.UserId);
            var role = _roleRepository.GetById(x.RoleId);

            return new UserRoleResponseModel
            {
                UserId = x.UserId,
                RoleId = x.RoleId,
                UserName = user != null ? user.UserName : string.Empty,
                RoleName = role != null ? role.Name : string.Empty
            };
        }).ToList();
    }

    public List<UserRoleResponseModel> GetByRoleId(int roleId)
    {
        var list = _userRoleRepository.GetAll().Where(x => x.RoleId == roleId).ToList();

        return list.Select(x =>
        {
            var user = _userRepository.GetById(x.UserId);
            var role = _roleRepository.GetById(x.RoleId);

            return new UserRoleResponseModel
            {
                UserId = x.UserId,
                RoleId = x.RoleId,
                UserName = user != null ? user.UserName : string.Empty,
                RoleName = role != null ? role.Name : string.Empty
            };
        }).ToList();
    }
}