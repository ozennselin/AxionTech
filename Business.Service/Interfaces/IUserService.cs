using Core.Models.Entities.User;

namespace Business.Service.Interfaces;

public interface IUserService
{
    void Create(CreateUserRequestModel request);
    void Update(UpdateUserRequestModel request);
    void Delete(DeleteUserRequestModel request);
    List<UserResponseModel> List();
    UserResponseModel? GetById(int id);
    LoginResponse Login(UserLoginModel request);
}
