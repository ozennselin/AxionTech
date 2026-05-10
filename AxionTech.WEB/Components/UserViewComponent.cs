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
        var getUserResponseDto = new UserResponseDto
        {
            Name=getUser
        };
        return View(getUserResponseDto);
    }
}
