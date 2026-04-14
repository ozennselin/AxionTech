using Core.Dtos;
using Core.Enums;
using Core.Models.Entities.Role;

namespace AxionTech.WEB.GetApi;

public class RoleApi
{
    private readonly HttpClient _httpClient;

    public RoleApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<RoleResponseModel> List()
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<List<RoleResponseModel>>>("Role/List")
            .Result;

        return response.Data;
    }

    public RoleResponseModel GetById(int id)
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<RoleResponseModel>>($"Role/GetById/{id}")
            .Result;

        return response.Data;
    }

    public ResponseMessageEnum Create(CreateRoleRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("Role/Create", request).Result;
        var result = response.Content.ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>().Result;
        return result.Data;
    }

    public ResponseMessageEnum Update(UpdateRoleRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("Role/Update", request).Result;
        var result = response.Content.ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>().Result;
        return result.Data;
    }

    public ResponseMessageEnum Delete(DeleteRoleRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("Role/Delete", request).Result;
        var result = response.Content.ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>().Result;
        return result.Data;
    }
}