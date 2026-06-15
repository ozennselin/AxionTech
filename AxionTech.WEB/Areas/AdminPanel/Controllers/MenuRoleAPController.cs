using AxionTech.WEB.GetApi;
using Core.Enums;
using Core.Models.Entities.MenuRole;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
public class MenuRoleAPController : Controller
{
    private readonly RoleApi _roleApi;
    private readonly MenuApi _menuApi;
    private readonly MenuRoleApi _menuRoleApi;

    public MenuRoleAPController(RoleApi roleApi, MenuApi menuApi, MenuRoleApi menuRoleApi)
    {
        _roleApi = roleApi;
        _menuApi = menuApi;
        _menuRoleApi = menuRoleApi;
    }

    public IActionResult Create()
    {
        MenuRoleCreatePageResponseModel model = new MenuRoleCreatePageResponseModel();

        model.Roles = _roleApi.List();

        model.Menus = _menuApi.List();
        var firstRole=model.Roles.FirstOrDefault();
        if (firstRole != null)
        {
            var selectedMenus = _menuRoleApi.GetByRoleId(firstRole.Id);

            model.SelectedMenuIds = selectedMenus != null
                ? selectedMenus.Select(x => x.MenuId).ToList()
                : new List<int>();
        }

        return View(model);
    }
    [HttpPost]
    public IActionResult Create(int roleId, List<int> menuIds)
    {
        List<CreateMenuRoleRequestModel> request = new List<CreateMenuRoleRequestModel>();

        foreach (var item in menuIds)
        {
            request.Add(new CreateMenuRoleRequestModel
            {
                RoleId = roleId,
                MenuId = item
            });
        }

        var result = _menuRoleApi.Create(request);

        if (result == ResponseMessageEnum.Success)
        {
            return RedirectToAction("Create");
        }

        ViewBag.Error = result.ToString();

        MenuRoleCreatePageResponseModel model = new MenuRoleCreatePageResponseModel();

        model.Roles = _roleApi.List();

        model.Menus = _menuApi.List();

        var selectedMenus = _menuRoleApi.GetByRoleId(roleId);

        model.SelectedMenuIds = selectedMenus != null
            ? selectedMenus.Select(x => x.MenuId).ToList()
            : new List<int>();

        return View(model);
    }
}