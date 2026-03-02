using Core.Dtos;
using Core.Models.Entities.Customer;

namespace AxionTech.WEB.GetApi;

public class CustomerApi
{
    private readonly HttpClient _httpClient;

    public CustomerApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<CustomerResponseModel> List()
    {
        var responseCustomer =
            _httpClient.GetFromJsonAsync<APIResponseDTO<List<CustomerResponseModel>>>
            ("Customer/List").Result;

        return responseCustomer.Data;
    }
}