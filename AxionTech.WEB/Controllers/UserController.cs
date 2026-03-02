using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class UserController : Controller
{
    private readonly UserApi _userApi;

    public UserController(UserApi userApi)
    {
        _userApi = userApi;
    }

    public IActionResult List()
    {
        var list = _userApi.List();
        return View(list);
    }
   
}
