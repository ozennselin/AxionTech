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
    public CustomerResponseModel GetById(int id)
    {
        var responseCustomer =
            _httpClient.GetFromJsonAsync<APIResponseDTO<CustomerResponseModel>>
            ($"Customer/GetById/{id}").Result;

        return responseCustomer.Data;
    }
    public string Update(UpdateCustomerRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("Customer/Update", request).Result;
        var content = response.Content.ReadAsStringAsync().Result;

        if (response.IsSuccessStatusCode)
        {
            return "SUCCESS";
        }

        return content;
    }

    public bool Delete(DeleteCustomerRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("Customer/Delete", request).Result;
        return response.IsSuccessStatusCode;
    }
    public bool Create(CreateCustomerRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("Customer/Create", request).Result;
        return response.IsSuccessStatusCode;
    }
}