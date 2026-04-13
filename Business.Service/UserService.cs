using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.User;
using Data.Access.Repositories;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }
    public ResponseMessageEnum Create(CreateUserRequestModel request)
    {
        try
        {
            User user = new User();

            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.PasswordHash = request.PasswordHash;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.DateOfBirth = request.DateOfBirth;
            user.Gender = request.Gender;
            user.IsActive = true;
            user.IsEmailConfirmed = false;

            _userRepository.Add(user);

            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }

    public ResponseMessageEnum Delete(DeleteUserRequestModel request)
    {
        try
        {
            var getUser = _userRepository.GetById(request.Id);

            if (getUser == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            getUser.IsActive = false;
            _userRepository.Update(getUser);

            return ResponseMessageEnum.Success;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.DeleteErrorWithMessage;
        }
    }

    public UserResponseModel? GetById(int id)
    {
        var user = _userRepository.GetAll()
     .FirstOrDefault(x => x.Id == id);

        if (user == null)
            return null;

        return new UserResponseModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            PasswordHash = user.PasswordHash,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DateOfBirth = user.DateOfBirth,
            Gender = user.Gender,
            IsActive = user.IsActive,
            IsEmailConfirmed = user.IsEmailConfirmed
        };
    }

    public List<UserResponseModel> List()
    {
        var users = _userRepository
            .GetAll()
            .Where(x => x.IsActive == true)
            .ToList();

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
            IsEmailConfirmed = x.IsEmailConfirmed,
            RoleName = x.UserRoles
                .Select(r => r.Role.Name)
                .FirstOrDefault()

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

    public ResponseMessageEnum Update(UpdateUserRequestModel request)
    {
        try
        {
            var getUser = _userRepository.GetById(request.Id);

            if (getUser == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            getUser.UserName = request.UserName;
            getUser.Email = request.Email;
            getUser.PhoneNumber = request.PhoneNumber;
            getUser.PasswordHash = request.PasswordHash;
            getUser.FirstName = request.FirstName;
            getUser.LastName = request.LastName;
            getUser.DateOfBirth = request.DateOfBirth;
            getUser.Gender = request.Gender;
            getUser.IsActive = request.IsActive;
            getUser.IsEmailConfirmed = request.IsEmailConfirmed;

            _userRepository.Update(getUser);
            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }
}
