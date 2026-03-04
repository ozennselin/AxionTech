using Core.Dtos;
using Core.Models.Entities.ProductDocument;

namespace AxionTech.WEB.GetApi;

public class ProductDocumentApi
{
    private readonly HttpClient _httpClient;
    public ProductDocumentApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public List<ProductDocumentResponseModel> List()
    {
        var responseProductDocument = _httpClient.GetFromJsonAsync<APIResponseDTO<List<ProductDocumentResponseModel>>>("ProductDocument/List").Result;
        return responseProductDocument.Data;
    }
}
