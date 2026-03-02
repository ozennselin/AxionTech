using Business.Service.Interfaces;
using Core.Models.Entities.Role;
using Data.Access.Repositories.Interfaces;

namespace Business.Service;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public void Create(CreateRoleRequestModel request)
    {
        throw new NotImplementedException();
    }

    public void Delete(DeleteRoleRequestModel request)
    {
        throw new NotImplementedException();
    }

    public RoleResponseModel? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<RoleResponseModel> List()
    {
        var roles = _roleRepository.GetAll().ToList();

        return roles.Select(x => new RoleResponseModel
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }

    public void Update(UpdateRoleRequestModel request)
    {
        throw new NotImplementedException();
    }
}
