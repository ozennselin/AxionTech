using Core.Dtos;
using Core.Models.Entities.Cart;

namespace AxionTech.WEB.GetApi;

public class CartApi
{
    private readonly HttpClient _httpClient;

    public CartApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public List<CartResponseModel> List()
    {
        var response = _httpClient.GetFromJsonAsync<List<CartResponseModel>>("Cart/List").Result;
        return response ?? new List<CartResponseModel>();
    }
}
