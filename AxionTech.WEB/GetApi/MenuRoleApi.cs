using Core.Dtos;
using Core.Enums;
using Core.Models.Entities.MenuRole;

namespace AxionTech.WEB.GetApi;

public class MenuRoleApi
{
    private readonly HttpClient _httpClient;

    public MenuRoleApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public ResponseMessageEnum Create(List<CreateMenuRoleRequestModel> request)
    {
        var response = _httpClient
            .PostAsJsonAsync("MenuRole/Create", request)
            .Result;

        var result = response.Content
            .ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>()
            .Result;

        return result.Data;
    }
    public List<MenuRoleResponseModel> List()
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<List<MenuRoleResponseModel>>>("MenuRole/List")
            .Result;

        return response.Data;
    }
}