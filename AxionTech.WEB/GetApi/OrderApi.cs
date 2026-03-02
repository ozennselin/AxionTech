using Core.Models.Entities.Order;

namespace AxionTech.WEB.GetApi;

public class OrderApi
{
    private readonly HttpClient _httpClient;

    public OrderApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<OrderResponseModel> List()
    {
        var response = _httpClient
            .GetFromJsonAsync<List<OrderResponseModel>>("Order/List")
            .Result;

        return response ?? new List<OrderResponseModel>();
    }
}
