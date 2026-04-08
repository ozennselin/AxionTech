using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Login(string user)
    {
        return View();
    }
}
