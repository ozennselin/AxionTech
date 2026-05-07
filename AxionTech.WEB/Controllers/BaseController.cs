using Core.Dtos;
using Core.Dtos.Entities.User;
using Core.Models.Entities.Category;
using Core.Models.Entities.User;
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


    public UserResponseDto  GetUser()
    {
        var getUserName = HttpContext.Session.GetString("UserName");
        if (getUserName == null)
        {
            return new UserResponseDto();//null dönmek yerine boş bir UserResponseDto döndürüyoruz
        }

        var user = new UserResponseDto
        {
            Id = 1,
            Name = getUserName,
            RoleId = 2,
            Role = "x Role"
        };
        return user;
    }
}
