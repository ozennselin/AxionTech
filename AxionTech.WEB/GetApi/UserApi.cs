using Core.Dtos;
using Core.Enums;
using Core.Models.Entities.User;
using Data.Infrastructure.Entities;

namespace AxionTech.WEB.GetApi;

public class UserApi
{
    private readonly HttpClient _httpClient;

    public UserApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<UserResponseModel> List()
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<List<UserResponseModel>>>("User/List")
            .Result;

        return response.Data;
    }

    public UserResponseModel GetById(int id)
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<UserResponseModel>>($"User/GetById/{id}")
            .Result;

        return response.Data;
    }

    public ResponseMessageEnum Create(CreateUserRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("User/Create", request).Result;
        var result = response.Content.ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>().Result;
        return result.Data;
    }

    public ResponseMessageEnum Update(UpdateUserRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("User/Update", request).Result;
        var result = response.Content.ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>().Result;
        return result.Data;
    }

    public ResponseMessageEnum Delete(DeleteUserRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("User/Delete", request).Result;
        var result = response.Content.ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>().Result;
        return result.Data;
    }
    public List<Role> GetRoles()
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<List<Role>>>("User/GetRoles")
            .Result;

        return response.Data;
    }
}