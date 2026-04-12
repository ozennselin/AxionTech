using Business.Service.Interfaces;
using Core.Models.Entities.User;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

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
        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            PasswordHash = request.PasswordHash,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            IsActive = true,
            IsEmailConfirmed = false
        };

        _userRepository.Add(user);
    }

    public void Delete(DeleteUserRequestModel request)
    {
        var user = _userRepository.GetAll()
        .FirstOrDefault(x => x.Id == request.Id);

        if (user == null)
            return;

        user.IsActive = false;

        _userRepository.Update(user);
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
        var user = _userRepository.GetAll()
            .FirstOrDefault(x => x.UserName == request.UserName);

        if (user == null)
        {
            return new LoginResponse
            {
                Id = -1,
                UserName = "KULLANICI_YOK",
                Rule = "HATA"
            };
        }

        if (user.PasswordHash != request.Password)
        {
            return new LoginResponse
            {
                Id = -2,
                UserName = "SIFRE_HATALI",
                Rule = "HATA"
            };
        }

        var response = new LoginResponse
        {
            Id = user.Id,
            UserName = user.UserName,
            Rule = "User"
        };

        return response;
    }

    public void Update(UpdateUserRequestModel request)
    {
        var user = _userRepository.GetAll()
      .FirstOrDefault(x => x.Id == request.Id);

        if (user == null)
            return;

        user.UserName = request.UserName;
        user.Email = request.Email;
        user.PhoneNumber = request.PhoneNumber;
        user.PasswordHash = request.PasswordHash;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.DateOfBirth = request.DateOfBirth;
        user.Gender = request.Gender;
        user.IsActive = request.IsActive;
        user.IsEmailConfirmed = request.IsEmailConfirmed;

        _userRepository.Update(user);
    }
}
