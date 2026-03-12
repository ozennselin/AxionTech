using Core.Dtos;
using Core.Models.Entities.Product;
using Humanizer;
using Newtonsoft.Json;

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
    public ProductResponseModel Detail(int id)
    {
        //get, post, put, delete
        //var response = _httpClient.PutAsJsonAsync($"Product/Detail?id=",Id);
        //var response = _httpClient.GetFromJsonAsync<APIResponseDTO< ProductResponseModel>>($"Product/Detail?id={Id}");
        var response = _httpClient.GetAsync($"Product/Detail?id={Id}");
        var content = response.Result.Content.ReadAsStringAsync();

        if (content.IsCompletedSuccessfully )
        {
            var responseContent=JsonConvert.DeserializeObject<APIResponseDTO<ProductResponseModel>>(content.Result);
            return responseContent.Data;
        }
            return null;
    }
    public ProductResponseModel GetById(int id)
    {
        var response = _httpClient.GetAsync($"Product/GetById?Id={id}").Result;
        var content = response.Content.ReadAsStringAsync();

        if (content.IsCompletedSuccessfully)
        {
            var responseContent = JsonConvert.DeserializeObject<APIResponseDTO<ProductResponseModel>>(content.Result);
            var responseContent1 = JsonConvert.DeserializeObject(content.Result);
            return responseContent.Data;
        }
        //<APIResponseDTO<ProductResponseModel>>($"Product/Detail/{Id}").Result;
        return null;
    }

    public ProductResponseModel GetById(int id)
    {
        var response = _httpClient.GetAsync($"Product/GetById?Id={id}").Result;
        var content = response.Content.ReadAsStringAsync();

        if (content.IsCompletedSuccessfully)
        {
         var responseContent= JsonConvert.DeserializeObject<APIResponseDTO<ProductResponseModel>>(content.Result);
         var responseContent1= JsonConvert.DeserializeObject(content.Result);
           return responseContent.Data;
        }
        //<APIResponseDTO<ProductResponseModel>>($"Product/Detail/{Id}").Result;
        return null;
    }



}
