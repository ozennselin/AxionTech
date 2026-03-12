using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

public class ProductDocumentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
