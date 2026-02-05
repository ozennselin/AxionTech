using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class AccountController : BaseController
{
    public AccountController(HttpClient httpClient) : base(httpClient)
    {
    }

    public IActionResult MyAccount()
    {
        return View();
    }
}
