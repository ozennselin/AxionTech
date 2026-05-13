using AxionTech.WEB.GetApi;
using Core.Enums;
using Core.Models.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class UserAPController : Controller
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

    public IActionResult Detail(int id)
    {
        var user = _userApi.GetById(id);
        return View(user);
    }

    public IActionResult Create()
    {
        var roles = _userApi.GetRoles();
        ViewBag.Roles = roles;

        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateUserRequestModel request)
    {
        var result = _userApi.Create(request);
      

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
            return RedirectToAction("List");

        ViewBag.Error = result.ToString();
        return View(request);
    }

    public IActionResult Update(int id)
    {
        var user = _userApi.GetById(id);
        var roles = _userApi.GetRoles();

        ViewBag.Roles = roles;

        return View(user);
    }

    [HttpPost]
    public IActionResult Update(UpdateUserRequestModel request)
    {
        var result = _userApi.Update(request);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
            return RedirectToAction("List");

        ViewBag.Error = result.ToString();
        var user = _userApi.GetById(request.Id);
        return View(user);
    }

    public IActionResult Delete(int id)
    {
        var user = _userApi.GetById(id);
        return View(user);
    }

    [HttpPost]
    public IActionResult Delete(DeleteUserRequestModel request)
    {
        var result = _userApi.Delete(request);

        if (result == ResponseMessageEnum.Success)
            return RedirectToAction("List");

        return View();
    }

    public IActionResult AssignRole(int id)
    {
        return View();
    }

}