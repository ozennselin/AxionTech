using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class RoleAPController:Controller
{
    private readonly RoleApi _roleApi;

    public RoleAPController(RoleApi roleApi)
    {
        _roleApi = roleApi;
    }
    public IActionResult List()
    {
        var list = _roleApi.List();
        return View(list);
    }
}
