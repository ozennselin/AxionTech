using Core.Dtos;
using Core.Models.Entities.Category;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace AxionTech.WEB.Controllers;

public class HomeController : Controller
{
   // https://html.design/download/igtu-electronics-ecommerce-template/
   //templete bu linkten alýndý

    HttpClient _httpClient;

    public HomeController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IActionResult Index()
    {
        var uriApiAdres = "https://localhost:7162/api/Category/List";

        var response = _httpClient.GetFromJsonAsync<APIResponseDTO<List<CategoryResponseModel>>>(uriApiAdres).Result;
        ViewBag.category = response.Data;

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
