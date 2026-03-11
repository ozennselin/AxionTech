using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers
{
    public class ProductAPController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
