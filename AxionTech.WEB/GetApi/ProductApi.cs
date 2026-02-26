using Core.Dtos;
using Core.Models.Entities.Product;

namespace AxionTech.WEB.GetApi;

public class ProductApi
{
    private readonly HttpClient _httpClient;

    public ProductApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<ProductResponseModel> List()
    {
        var responseProduct = _httpClient.GetFromJsonAsync<APIResponseDTO<List<ProductResponseModel>>>("Product/List").Result;
        return responseProduct.Data;
    }
    public ProductResponseModel Detail(int Id)
    {
        //get, post, put, delete
        //var response = _httpClient.PutAsJsonAsync($"Product/Detail?id=",Id);
        //var response = _httpClient.GetFromJsonAsync<APIResponseDTO< ProductResponseModel>>($"Product/Detail?id={Id}");
        var response = _httpClient.GetAsync($"Product/Detail?id={Id}");
        var content = response.Result.Content.ReadAsStringAsync();

        if (response.Result.IsSuccessStatusCode == false)
            return null;

        //<APIResponseDTO<ProductResponseModel>>($"Product/Detail/{Id}").Result;
        return null;
    }

}
