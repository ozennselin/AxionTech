using Core.Dtos;
using Core.Enums;
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
            .GetFromJsonAsync<APIResponseDTO<List<OrderResponseModel>>>("Order/List")
            .Result;

        return response.Data;
    }

    public OrderResponseModel GetById(int id)
    {
        var response = _httpClient
            .GetFromJsonAsync<APIResponseDTO<OrderResponseModel>>($"Order/GetById/{id}")
            .Result;

        return response.Data;
    }

    public ResponseMessageEnum UpdateStatus(int orderId, string status)
    {
        var response = _httpClient
            .PostAsync($"Order/UpdateStatus?orderId={orderId}&status={status}", null)
            .Result;

        var result = response.Content
            .ReadFromJsonAsync<APIResponseDTO<ResponseMessageEnum>>()
            .Result;

        return result.Data;
    }
}