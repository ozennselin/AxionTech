using Azure;
using Core.Models.Entities.User;
using System.Text;
using System.Text.Json;

namespace AxionTech.WEB.GetApi;

public class LoginApi
{

    private readonly HttpClient _httpClient;

    public LoginApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResponse> Login(UserLoginModel loginModel)
    {
        var jsonData = JsonSerializer.Serialize(loginModel);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://localhost:7162/api/User/Login", content);

        var responseContent = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(responseContent))
        {
            loginModel.Message = "Status: " + response.StatusCode.ToString();
            //return View(loginModel);
        }

        var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return  loginResponse;
    }

}
