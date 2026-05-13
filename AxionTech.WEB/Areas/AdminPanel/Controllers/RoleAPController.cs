using AxionTech.WEB.GetApi;
using Core.Enums;
using Core.Models.Entities.Role;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]

public class RoleAPController : Controller
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

    public IActionResult Detail(int id)
    {
        var role = _roleApi.GetById(id);
        return View(role);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateRoleRequestModel request)
    {
        var result = _roleApi.Create(request);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
            return RedirectToAction("List");

        ViewBag.Error = result.ToString();
        return View(request);
    }

    public IActionResult Update(int id)
    {
        var role = _roleApi.GetById(id);
        return View(role);
    }

    [HttpPost]
    public IActionResult Update(UpdateRoleRequestModel request)
    {
        var result = _roleApi.Update(request);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
            return RedirectToAction("List");

        ViewBag.Error = result.ToString();
        var role = _roleApi.GetById(request.Id);
        return View(role);
    }

    public IActionResult Delete(int id)
    {
        var role = _roleApi.GetById(id);
        return View(role);
    }

    [HttpPost]
    public IActionResult Delete(DeleteRoleRequestModel request)
    {
        var result = _roleApi.Delete(request);

        if (result == ResponseMessageEnum.Success)
            return RedirectToAction("List");

        return View();
    }
}