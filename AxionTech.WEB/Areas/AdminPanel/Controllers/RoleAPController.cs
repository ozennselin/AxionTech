using AxionTech.WEB.GetApi;
using Core.Enums;
using Core.Models.Entities.MenuRole;
using Core.Models.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Core.Models.Entities.MenuRole;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]

public class RoleAPController : Controller
{
    private readonly RoleApi _roleApi;
    private readonly MenuApi _menuApi;
    private readonly MenuRoleApi _menuRoleApi;

    public RoleAPController(RoleApi roleApi,
    MenuApi menuApi,
    MenuRoleApi menuRoleApi)
    {
        _roleApi = roleApi;
        _menuApi = menuApi;
        _menuRoleApi = menuRoleApi;
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
        ViewData["SelectedMenuIds"] = new List<int>();

        var menus = _menuApi.List();

        return View(menus);
    }

    [HttpPost]
    public IActionResult Create(CreateRoleRequestModel request)
    {
        var result = _roleApi.Create(request);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
        {
            var role = _roleApi.List()
                .Where(x => x.Name == request.Name)
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            if (role != null && request.MenuIds != null && request.MenuIds.Any())
            {
                List<CreateMenuRoleRequestModel> menuRoleRequest = new List<CreateMenuRoleRequestModel>();

                foreach (var menuId in request.MenuIds)
                {
                    menuRoleRequest.Add(new CreateMenuRoleRequestModel
                    {
                        RoleId = role.Id,
                        MenuId = menuId
                    });
                }

                _menuRoleApi.Create(menuRoleRequest);
            }

            return RedirectToAction("List");
        }

        ViewBag.Error = result.ToString();

        ViewData["SelectedMenuIds"] = request.MenuIds ?? new List<int>();

        return View(_menuApi.List());
    }

    public IActionResult Update(int id)
    {
        var role = _roleApi.GetById(id);

        RoleUpdatePageResponseModel model = new RoleUpdatePageResponseModel();

        model.Role = role;

        model.Menus = _menuApi.List();

        var selectedMenus = _menuRoleApi.GetByRoleId(id);

        model.SelectedMenuIds = selectedMenus != null
      ? selectedMenus.Where(x => x.IsActive).Select(x => x.MenuId).ToList()
      : new List<int>();

        return View(model);
    }

    [HttpPost]
    public IActionResult Update(UpdateRoleRequestModel request)
    {
        var result = _roleApi.Update(request);

        if (result == ResponseMessageEnum.Success ||
            result == ResponseMessageEnum.UpdateSuccess)
        {
            UpdateMenuRoleRequestModel menuRoleRequest =
                new UpdateMenuRoleRequestModel();

            menuRoleRequest.RoleId = request.Id;
            menuRoleRequest.MenuIds = request.MenuIds;

            _menuRoleApi.Update(menuRoleRequest);

            return RedirectToAction("List");
        }

        ViewBag.Error = result.ToString();

        var role = _roleApi.GetById(request.Id);

        RoleUpdatePageResponseModel model = new RoleUpdatePageResponseModel();

        model.Role = role;

        model.Menus = _menuApi.List();

        var selectedMenus = _menuRoleApi.GetByRoleId(request.Id);

        model.SelectedMenuIds = selectedMenus != null
            ? selectedMenus.Select(x => x.MenuId).ToList()
            : new List<int>();

        return View(model);
    }

    public IActionResult Delete(int id)
    {
        var role = _roleApi.GetById(id);

        RoleDeletePageResponseModel model = new RoleDeletePageResponseModel();

        model.Role = role;

        model.Menus = _menuApi.List();

        var selectedMenus = _menuRoleApi.GetByRoleId(id);

        model.SelectedMenuIds = selectedMenus != null
            ? selectedMenus.Where(x => x.IsActive).Select(x => x.MenuId).ToList()
            : new List<int>();

        return View(model);
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