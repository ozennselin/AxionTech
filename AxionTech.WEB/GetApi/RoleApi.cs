using Core.Dtos;
using Core.Models.Entities.Role;
using System.Net.Http.Json;

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
}