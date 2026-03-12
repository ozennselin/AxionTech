using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

public class OrderItemController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
