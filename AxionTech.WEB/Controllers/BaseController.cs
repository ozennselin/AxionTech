using Core.Dtos;
using Core.Models.Entities.Category;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class BaseController : Controller
{
   public HttpClient _httpClient;

    public BaseController(HttpClient httpClient)
    {
         _httpClient = httpClient;
    }

    
    public IActionResult Test()
    {
        return View();
    }
}
