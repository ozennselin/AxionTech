using Core.Dtos;
using Core.Models.Entities.Product;

namespace AxionTech.WEB.GetApi;

public class ProductApi
{
    private readonly HttpClient _httpClient;

    public ProductApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<ProductResponseModel> List()
    {
        var responseProduct = _httpClient.GetFromJsonAsync<APIResponseDTO<List<ProductResponseModel>>>("Product/List").Result;
        return responseProduct.Data;
    }
}
