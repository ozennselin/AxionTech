using Core.Models.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(UserLoginModel loginModel)
    {

        return View();
    }
}
