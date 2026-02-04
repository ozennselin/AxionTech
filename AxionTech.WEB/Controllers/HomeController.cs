using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class HomeController : Controller
{
   // https://html.design/download/igtu-electronics-ecommerce-template/
   //templete bu linkten alýndý
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Service()
    {
        return View();
    }
    public IActionResult ContactUs()
    {
        return View();
    }


}
