using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
