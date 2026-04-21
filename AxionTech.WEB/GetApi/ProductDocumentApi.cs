using Core.Dtos;
using Core.Models.Entities.ProductDocument;
using System.Net.Http.Json;

namespace AxionTech.WEB.GetApi;

public class ProductDocumentApi
{
    private readonly HttpClient _httpClient;
    public ProductDocumentApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public List<ProductDocumentResponseModel> List(int productId)
    {
        var responseProductDocument = _httpClient.GetFromJsonAsync<APIResponseDTO<List<ProductDocumentResponseModel>>>("ProductDocument/GetByProductId?Id=" + productId).Result;

        return responseProductDocument.Data;
    }
    public bool Create(CreateProductDocumentRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync("ProductDocument/Create", request).Result;
        return response.IsSuccessStatusCode;
    }

    public bool Delete(int id)
    {
        var response = _httpClient.DeleteAsync("ProductDocument/Delete?Id=" + id).Result;
        return response.IsSuccessStatusCode;
    }


}
