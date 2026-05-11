using AxionTech.WEB.GetApi;
using Core.Enums;
using Core.Models.Entities.User;
using Microsoft.AspNetCore.Mvc;

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
            return RedirectToAction("Index", "Home");
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
}