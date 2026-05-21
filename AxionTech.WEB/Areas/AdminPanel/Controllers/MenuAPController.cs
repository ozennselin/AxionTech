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
    public IActionResult Detail(int id)
    {
        var menu = _menuApi.GetById(id);

        return View(menu);
    }
    public IActionResult Update(int id)
    {
        var menu = _menuApi.GetById(id);

        return View(menu);
    }

    [HttpPost]
    public IActionResult Update(UpdateMenuRequestModel request)
    {
        var result = _menuApi.Update(request);

        if (result == ResponseMessageEnum.Success ||
            result == ResponseMessageEnum.UpdateSuccess)
        {
            return RedirectToAction("List");
        }

        ViewBag.Error = result.ToString();

        var menu = _menuApi.GetById(request.Id);

        return View(menu);
    }
    public IActionResult Delete(int id)
    {
        var menu = _menuApi.GetById(id);

        return View(menu);
    }

    [HttpPost]
    public IActionResult Delete(DeleteMenuRequestModel request)
    {
        var result = _menuApi.Delete(request);

        if (result == ResponseMessageEnum.Success)
        {
            return RedirectToAction("List");
        }

        return View();
    }
}
