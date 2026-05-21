using Core.Dtos;
using Core.Enums;
using Core.Models.Entities.Menu;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.GetApi;

public class MenuApi
{
    private readonly HttpClient _httpClient;

    public MenuApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public ResponseMessageEnum Create(CreateMenuRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("menu/Create", request).Result;
        var result= response.Content.ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>().Result;
        return result.Data;
    }
    public List<MenuResponseModel> List()
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<List<MenuResponseModel>>>("Menu/List")
            .Result;

        return response.Data;
    }
    public MenuResponseModel GetById(int id)
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<MenuResponseModel>>($"Menu/GetById/{id}")
            .Result;

        return response.Data;
    }
    public ResponseMessageEnum Update(UpdateMenuRequestModel request)
    {
        var response = _httpClient
            .PostAsJsonAsync("Menu/Update", request)
            .Result;

        var result = response.Content
            .ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>()
            .Result;

        return result.Data;
    }
    public ResponseMessageEnum Delete(DeleteMenuRequestModel request)
    {
        var response = _httpClient
            .PostAsJsonAsync("Menu/Delete", request)
            .Result;

        var result = response.Content
            .ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>()
            .Result;

        return result.Data;
    }
}
