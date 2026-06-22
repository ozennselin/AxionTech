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
    
    /// <summary>
    /// Getall MenuRole List
    /// </summary>
    /// <returns></returns>
    public List<MenuRoleResponseModel> List()
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<List<MenuRoleResponseModel>>>("MenuRole/List")
            .Result;

        return response.Data;
    }

    /// <summary>
    /// List with RoleId
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public List<MenuRoleResponseModel> List(int roleId)
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<List<MenuRoleResponseModel>>>($"MenuRole/List?roleId={roleId}")
            .Result;

        return response.Data;
    }
    public List<MenuRoleResponseModel> GetByRoleId(int roleId)
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<List<MenuRoleResponseModel>>>($"MenuRole/GetByRoleId?roleId={roleId}")
            .Result;

        return response.Data;
    }
    public ResponseMessageEnum Update(UpdateMenuRoleRequestModel request)
    {
        var response = _httpClient
            .PostAsJsonAsync("MenuRole/Update", request)
            .Result;

        var result = response.Content
            .ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>()
            .Result;

        return result.Data;
    }
}