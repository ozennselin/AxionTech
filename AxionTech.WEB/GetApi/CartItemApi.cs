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
    public bool Delete(DeleteCartItemRequestModel request)
    {
        var response = _httpClient.PutAsJsonAsync("CartItem/Delete", request).Result;

        return response.IsSuccessStatusCode;
    }
}
