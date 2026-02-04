using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Wishlist()
        {
            return View();
        }
    }
}
