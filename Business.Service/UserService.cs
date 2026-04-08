using Business.Service.Interfaces;
using Core.Models.Entities.User;
using Data.Access.Repositories.Interfaces;

namespace Business.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public void Create(CreateUserRequestModel request)
    {
        throw new NotImplementedException();
    }

    public void Delete(DeleteUserRequestModel request)
    {
        throw new NotImplementedException();
    }

    public UserResponseModel? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<UserResponseModel> List()
    {
        var users = _userRepository.GetAll().ToList();

        return users.Select(x => new UserResponseModel
        {
            Id = x.Id,
            UserName = x.UserName,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            PasswordHash = x.PasswordHash,
            FirstName = x.FirstName,
            LastName = x.LastName,
            DateOfBirth = x.DateOfBirth,
            Gender = x.Gender,
            IsActive = x.IsActive,
            IsEmailConfirmed = x.IsEmailConfirmed
        }).ToList();
    }

    public LoginResponse Login(UserLoginModel request)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateUserRequestModel request)
    {
        throw new NotImplementedException();
    }
}
