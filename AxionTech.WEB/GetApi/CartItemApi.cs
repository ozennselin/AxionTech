using Core.Dtos;
using Core.Models.Entities.CartItem;

namespace AxionTech.WEB.GetApi;

public class CartItemApi
{
    private readonly HttpClient _httpClient;

    public CartItemApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<CartItemResponseModel> List()
    {
        var response = _httpClient
            .GetFromJsonAsync<List<CartItemResponseModel>>("CartItem/List")
            .Result;

        return response ?? new List<CartItemResponseModel>();
    }
    public List<CartItemResponseModel> GetByCartId(int cartId)
    {
        var response = _httpClient
            .GetFromJsonAsync<List<CartItemResponseModel>>($"CartItem/{cartId}")
            .Result;

        return response ?? new List<CartItemResponseModel>();
    }
}
