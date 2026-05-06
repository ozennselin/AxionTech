using AxionTech.WEB.GetApi;
using Core.Dtos;
using Core.Models.Entities.Category;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace AxionTech.WEB.Controllers;

public class HomeController : BaseController
{
    // https://html.design/download/igtu-electronics-ecommerce-template/
    //templete bu linkten alýndý
    private readonly CategoryApi _categoryApi;

    public HomeController(HttpClient httpClient, CategoryApi categoryApi) : base(httpClient)
    {
        _categoryApi = categoryApi;
    }

    public IActionResult Index()
    {
        #region API baðlantýlarý, datalarýn çekilmesi dosya,class taþýnmadan önce
        //var uriApiAdres = "https://localhost:7162/api/Category/List";
        //var response = _httpClient.GetFromJsonAsync<APIResponseDTO<List<CategoryResponseModel>>>(uriApiAdres).Result;
        //ViewBag.category = response.Data; 
        #endregion

       // ViewBag.category = _categoryApi.List();//Component yapýldý
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
