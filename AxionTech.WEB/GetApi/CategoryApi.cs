using Core.Dtos;
using Core.Enums;
using Core.Models.Entities.Category;

namespace AxionTech.WEB.GetApi;

public class CategoryApi
{
    private readonly HttpClient _httpClient;

    public CategoryApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<CategoryResponseModel> List()
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<List<CategoryResponseModel>>>("Category/List")
            .Result;

        return response.Data;
    }

    public CategoryResponseModel GetById(int id)
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<CategoryResponseModel>>($"Category/GetById/{id}")
            .Result;

        return response.Data;
    }

    public ResponseMessageEnum Create(CreateCategoryRequestModel request)
    {
        var response = _httpClient
            .PostAsJsonAsync("Category/Create", request)
            .Result;

        var result = response.Content
            .ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>()
            .Result;

        return result.Data;
    }

    public ResponseMessageEnum Update(UpdateCategoryRequestModel request)
    {
        var response = _httpClient
            .PostAsJsonAsync("Category/Update", request)
            .Result;

        var result = response.Content
            .ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>()
            .Result;

        return result.Data;
    }

    public ResponseMessageEnum Delete(DeleteCategoryRequestModel request)
    {
        var response = _httpClient
            .PostAsJsonAsync("Category/Delete", request)
            .Result;

        var result = response.Content
            .ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>()
            .Result;

        return result.Data;
    }
}