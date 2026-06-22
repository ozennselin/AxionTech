using AxionTech.WEB.GetApi;
using Core.Enums;
using Core.Models.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
public class AdminLoginAPController : Controller
{
    private readonly LoginApi _loginApi;

    public AdminLoginAPController(LoginApi loginApi)
    {
        _loginApi = loginApi;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginModel loginModel)
    {
        var result = await _loginApi.Login(loginModel);

        if (result != null && result.Id > 0)
        {
            HttpContext.Session.SetString("AdminPanelUserName", result.UserName);
            HttpContext.Session.SetInt32("AdminPanelUserId", result.Id);
            return RedirectToAction("Index", "Dashboard", new { area = "AdminPanel" });
        }

        loginModel.Message = ResponseMessageEnum.UserNameOrPasswordFailed.ToString();
        return View(loginModel);
    }
}
