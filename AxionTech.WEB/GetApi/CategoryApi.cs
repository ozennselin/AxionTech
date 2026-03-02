using Core.Dtos;
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
        var responseCategory = _httpClient.GetFromJsonAsync<APIResponseDTO<List<CategoryResponseModel>>>("Category/List").Result;
        return responseCategory.Data;

    }
}
