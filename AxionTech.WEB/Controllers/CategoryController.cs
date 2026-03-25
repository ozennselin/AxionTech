using Core.Dtos;
using Core.Models.Entities.Category;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class CategoryController : BaseController
{
    public CategoryController(HttpClient httpClient) : base(httpClient)
    {
    }

    public IActionResult List()
    {
        var uriApiAdres = "https://localhost:7162/api/Category/List";
        #region API bağlantıları, dataların çekilmesi dosya,class taşınmadan önce
        //1.Durum
        //var httpResponse = _httpClient.GetAsync(uriApiAdres).GetAwaiter().GetResult();
        //var raw = httpResponse.Content.ReadAsStringAsync().Result;
        ////GetFromJsonAsync()=> json datasını alır
        //var option = new System.Text.Json.JsonSerializerOptions
        //{
        //    PropertyNameCaseInsensitive = true,
        //};
        //var dto = System.Text.Json.JsonSerializer.Deserialize<List<CategoryResponseModel>>(raw, option);
        //return View(dto);
        //2.Durum
        //var response = _httpClient.GetFromJsonAsync<APIResponseDTO<List<CategoryResponseModel>>>(uriApiAdres).Result;
        //return View(response.Data); 
        #endregion
        var response = _httpClient.GetFromJsonAsync<APIResponseDTO<List<CategoryResponseModel>>>(uriApiAdres).Result;
        return View(response.Data);
    }
}
