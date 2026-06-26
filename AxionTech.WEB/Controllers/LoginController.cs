using AxionTech.WEB.GetApi;
using Core.Enums;
using Core.Models.Entities.Cart;
using Core.Models.Entities.User;
using Data.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AxionTech.WEB.Controllers;

public class LoginController : Controller
{
    private readonly LoginApi _loginApi;

    public HttpClient _httpClient;
    public LoginController(LoginApi loginApi, HttpClient httpClient)
    {
        _loginApi = loginApi;
        _httpClient = httpClient;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginModel loginModel)
    {
        #region Login API Call  
        //using var httpClient = new HttpClient();

        //var jsonData = JsonSerializer.Serialize(loginModel);
        //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //var response = await httpClient.PostAsync("https://localhost:7162/api/User/Login", content);

        //var responseContent = await response.Content.ReadAsStringAsync();
        //if (string.IsNullOrWhiteSpace(responseContent))
        //{
        //    loginModel.Message = "Status: " + response.StatusCode.ToString();
        //    return View(loginModel);
        //}

        //var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent, new JsonSerializerOptions
        //{
        //    PropertyNameCaseInsensitive = true
        //});

        #endregion

        var loginUser = _loginApi.Login(loginModel);

        if (loginUser != null && loginUser.Id > 0)
        {
            HttpContext.Session.SetString("UserName", loginUser.Result.UserName);//Session oluşturme
                                                                                 //1. parametre Key=> Unique tir
                                                                                 //2.parametre Value=> bu kullanıcı girişi yaparken verilecek nickname, username, mail,.. olabilir
                                                                                 //Session Süre ver.
                                                                                 //iç layout ya da session farklı yönetim??
                                                                                 // ViewBag.userName = HttpContext.Session.GetString("UserName");
            HttpContext.Session.SetString("UserId", loginUser.Result.Id.ToString());
            //Cookie'de ürün varsa ürünleri giriş yapan kullanıcıya ata/sepetine ekle
           var cartItems = JsonSerializer.Deserialize<List<CreateCartCookieModel>>(Request.Cookies["guestCart"]);

            if (cartItems.Count()==0)
            {
            return RedirectToAction("Index", "Home");
            }
            //cookie ürünlerini ekleme alanı
            //1) javascript ile seesion yaparak ekle
            //2)json döndüren bir yapı ile ekle (klasik login olan kullanıcının sepete ekleme mantığı)
            //3)klasik login olan kullanıcı methoduna yönlendirme yaparak ekleme
            foreach (var item in cartItems)
            {
                return RedirectToAction("AddCart", "Cart",item.ProductId);
            }

            return Json(new { success = true });
        }
        if (loginUser != null && loginUser.Id == -2)
        {
            loginModel.Message = ResponseMessageEnum.UserNameOrPasswordFailed.ToString();
            return View(loginModel);
        }

        return View(loginModel);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUserRequestModel request)
    {
        var response = await _loginApi.Register(request);

        if (response)
        {
            return RedirectToAction("Login", "Login");
        }

        request.Message = ResponseMessageEnum.Error.ToString();
        return View(request);
    }

    [HttpGet]
    public IActionResult MyAccount()
    {
        var userName = HttpContext.Session.GetString("UserName");

        if (string.IsNullOrEmpty(userName))
        {
            return RedirectToAction("Login");
        }

        var model = new MyAccountResponseModel
        {
            UserName = userName
        };

        return View(model);
    }
}