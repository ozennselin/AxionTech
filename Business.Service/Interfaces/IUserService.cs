using Core.Enums;
using Core.Models.Entities.User;

namespace Business.Service.Interfaces;

public interface IUserService
{
    ResponseMessageEnum Create(CreateUserRequestModel request);
    ResponseMessageEnum Update(UpdateUserRequestModel request);
    ResponseMessageEnum Delete(DeleteUserRequestModel request);
    List<UserResponseModel> List();
    UserResponseModel? GetById(int id);
    LoginResponse Login(UserLoginModel request);
}