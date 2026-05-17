using Core.Dtos;
using Core.Enums;
using Core.Models.Entities.UserRole;

namespace AxionTech.WEB.GetApi;

public class UserRoleApi
{
    private readonly HttpClient _httpClient;

    public UserRoleApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public ResponseMessageEnum Create(CreateUserRoleRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("UserRole/Create", request).Result;

        var result = response.Content.ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>().Result;

        return result.Data;
    }

    public ResponseMessageEnum Update(UpdateUserRoleRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("UserRole/Update", request).Result;

        var result = response.Content.ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>().Result;

        return result.Data;
    }

    public ResponseMessageEnum Delete(DeleteUserRoleRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("UserRole/Delete", request).Result;

        var result = response.Content.ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>().Result;

        return result.Data;
    }

    public List<UserRoleResponseModel> GetByUserId(int userId)
    {
        var response = _httpClient.GetFromJsonAsync<APIResponseDTO<List<UserRoleResponseModel>>>($"UserRole/GetByUserId?userId={userId}").Result;

        return response.Data;
    }

    public List<UserRoleResponseModel> GetByRoleId(int roleId)
    {
        var response = _httpClient.GetFromJsonAsync<APIResponseDTO<List<UserRoleResponseModel>>>($"UserRole/GetByRoleId?roleId={roleId}").Result;

        return response.Data;
    }
}