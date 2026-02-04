using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class AccountController : Controller
{
    public IActionResult MyAccount()
    {
        return View();
    }
}
