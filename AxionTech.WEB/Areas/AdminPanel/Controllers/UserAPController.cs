using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class UserAPController:Controller
{
    private readonly UserApi _userApi;

    public UserAPController(UserApi userApi)
    {
        _userApi = userApi;
    }
    public IActionResult List()
    {
        var list = _userApi.List();
        return View(list);
    }
}
