using Core.Dtos;
using Core.Models.Entities.ProductPrice;

namespace AxionTech.WEB.GetApi;

public class ProductPriceApi
{
    private readonly HttpClient _httpClient;
    public ProductPriceApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public List<ProductPriceResponseModel> List()
    {
        var responseProductPrice = _httpClient.GetFromJsonAsync<APIResponseDTO<List<ProductPriceResponseModel>>>("ProductPrice/List").Result;
        return responseProductPrice.Data;
    }
}
