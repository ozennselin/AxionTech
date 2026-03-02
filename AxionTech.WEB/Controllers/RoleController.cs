using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class RoleController : Controller
{
    private readonly RoleApi _roleApi;

    public RoleController(RoleApi roleApi)
    {
        _roleApi = roleApi;
    }

    public IActionResult List()
    {
        var list = _roleApi.List();
        return View(list);
    }
}