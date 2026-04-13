using Core.Dtos;
using Core.Models.Entities.Cart;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        // var response = _httpClient.GetFromJsonAsync<List<CartResponseModel>>("Cart/List").Result;
        var response = _httpClient.GetFromJsonAsync<APIResponseDTO<List<CartResponseModel>>>("Cart/List").Result;
        return response.Data;
    }

    public bool AddCart(CreateCartRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync($"Cart/Create", request).Result;

        if (response != null)
        {
            return response.IsSuccessStatusCode;
        }

        return false;
    }
    public CartResponseModel GetByCartId(int id)
    {
        var response = _httpClient
            .GetFromJsonAsync<CartResponseModel>($"Cart/{id}")
            .Result;

        return response;
    }
    public bool Delete(DeleteCartRequestModel request)
    {
        var response = _httpClient.PutAsJsonAsync("Cart/Delete", request).Result;

        return response.IsSuccessStatusCode;
    }
    public bool Update(UpdateCartRequestModel request)
    {
        var response = _httpClient.PutAsJsonAsync("Cart/Update", request).Result;

        return response.IsSuccessStatusCode;
    }
}
