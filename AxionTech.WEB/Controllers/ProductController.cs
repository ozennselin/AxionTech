using Core.Dtos;
using Core.Models.Entities.Category;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(HttpClient httpClient) : base(httpClient)
        {
        }

        public IActionResult List()
        {
            var uriApiAdres = "https://localhost:7162/api/Category/List";

            var response = _httpClient.GetFromJsonAsync<APIResponseDTO<List<CategoryResponseModel>>>(uriApiAdres).Result;
            ViewBag.category = response.Data;

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
