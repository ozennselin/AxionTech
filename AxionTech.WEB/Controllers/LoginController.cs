using Core.Models.Entities.User;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AxionTech.WEB.Controllers;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginModel loginModel)
    {
        using var httpClient = new HttpClient();

        var jsonData = JsonSerializer.Serialize(loginModel);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("https://localhost:7162/api/User/Login", content);

        var responseContent = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(responseContent))
        {
            ViewBag.Error = "Status: " + response.StatusCode.ToString();
            return View(loginModel);
        }

        var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (loginResponse != null && loginResponse.Id > 0)
        {
            HttpContext.Session.SetString("UserName", loginResponse.UserName);
            return RedirectToAction("Index", "Home");
        }

        if (loginResponse != null && loginResponse.Id == -1)
        {
            ViewBag.Error = "Kullanıcı bulunamadı";
            return View(loginModel);
        }

        if (loginResponse != null && loginResponse.Id == -2)
        {
            ViewBag.Error = "Şifre hatalı";
            return View(loginModel);
        }
        ViewBag.Error = responseContent;
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
        using var httpClient = new HttpClient();

        var jsonData = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("https://localhost:7162/api/User/Create", content);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Login", "Login");
        }

        ViewBag.Error = "Kayıt işlemi başarısız";
        return View(request);
    }
}