using Core.Dtos.Entities.User;
using Core.Models.Entities.Cart;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AxionTech.WEB.Controllers;

public class BaseController : Controller
{
    public HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BaseController(HttpClient httpClient, IHttpContextAccessor httpContextAccessor=null)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }


    public IActionResult Test()
    {
        return View();
    }

    public UserResponseDto GetUser()
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

    public int GetSessionUserId()
    {
        var getUserId = HttpContext.Session.GetString("UserId");
        if (getUserId == null)
        {
            return 0;//null dönmek yerine 0 dönüyoruz
        }
        return int.Parse(getUserId);
    }


    #region Cookie işlemleri

     /// <summary>
    /// Cooki de olan json formatındaki ürünleri c# formatına dönüştürüp List olarak getirir
    /// </summary>
    /// <returns></returns>
    public List<CreateCartCookieModel> CookieProductList()
    {
        var cookieList = _httpContextAccessor.HttpContext.Request.Cookies["guestCart"];
        if (cookieList != null)
        {
            return JsonSerializer.Deserialize<List<CreateCartCookieModel>>(cookieList);//json formatında olan Cookiedeki ürünleri c# formatına getirecek
        }
        return new List<CreateCartCookieModel>();
    }

    /// <summary>
    /// Cookie oluşturma işlemi
    /// </summary>
    /// <param name="cartCookieItems"></param>
    public void AddToCartWithCookie(List<CreateCartCookieModel> cartCookieItems)
    {

        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(7),//cookie nin geçerlilik süresi
            HttpOnly = true,//sadece sunucu tarafından erişilebilir, client tarafında js ile erişilemez
            IsEssential = true,//kullanıcı onayı gerektirmez, zorunlu cookie
                               //Secure=true,            
        };

        //Response.Cookies.Append("guestCart", JsonSerializer.Serialize(cartItems), cookieOptions);//
        var jsonStirng = JsonSerializer.Serialize(cartCookieItems);//C# formatında olan ürünleri json formatına dönüştürecek
        _httpContextAccessor.HttpContext.Response.Cookies.Append("guestCart", jsonStirng, cookieOptions);

    }
   

    #endregion  
}
