using AxionTech.WEB.GetApi;
using Core.Enums;
using Core.Models.Entities.Menu;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]

public class MenuAPController : Controller
{
    private readonly MenuApi _menuApi;

    public MenuAPController(MenuApi menuApi)
    {
        _menuApi = menuApi;
    }
    public IActionResult List()
    {
        var list = _menuApi.List();

        return View(list);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateMenuRequestModel request)
    {
        var result= _menuApi.Create(request);
        if (result == ResponseMessageEnum.Success)
        {
            return RedirectToAction("Create");
        }
        ViewBag.Error = result.ToString();
        return View(request);
    }


}
