using Core.Dtos;
using Core.Models.Entities.CartItem;
using Newtonsoft.Json;

namespace AxionTech.WEB.GetApi;

public class CartItemApi
{
    private readonly HttpClient _httpClient;

    public CartItemApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<CartItemResponseModel> List(int userId)
    {
        var response = _httpClient.GetFromJsonAsync<APIResponseDTO<List<CartItemResponseModel>>>($"CartItem/List?userId={userId}").Result;

        return response?.Data ?? new List<CartItemResponseModel>();
        //var content=response.Content.ReadAsStringAsync();
        //if (content.IsCompletedSuccessfully)
        //{
        //   var result = JsonConvert.DeserializeObject<APIResponseDTO<List<CartItemResponseModel>>>(content.Result);
        //    return result.Data;
        //}
        //return  new List<CartItemResponseModel>();
    }
    public List<CartItemResponseModel> GetByCartId(int userId)
    {
        var response = _httpClient
            .GetFromJsonAsync<List<CartItemResponseModel>>($"CartItem/{userId}")
            .Result;

        return response ?? new List<CartItemResponseModel>();
    }
    public bool Delete(DeleteCartItemRequestModel request)
    {
        var response = _httpClient.PutAsJsonAsync("CartItem/Delete", request).Result;

        return response.IsSuccessStatusCode;
    }


}
