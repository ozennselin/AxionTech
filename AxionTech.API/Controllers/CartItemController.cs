using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

public class CartItemController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
