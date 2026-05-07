using AxionTech.WEB.GetApi;
using Core.Dtos.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Components;

[ViewComponent(Name="User")]
public class UserViewComponent : ViewComponent
{
    private readonly UserApi _userApi;


    public UserViewComponent(UserApi userApi)
    {
        _userApi = userApi;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {

        var getUser = HttpContext.Session.GetString("UserName");

        if (getUser == null)
        {
            return View(new UserResponseDto());
        }

        var user = _userApi.GetById(2);
        var getUserResponseDto = new UserResponseDto
        {
            Id = 1,
            Name = getUser,
            Role = "x Role",
            RoleId = 2

        };
        return View(getUserResponseDto);
    }
}
