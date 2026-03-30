using Core.Dtos;
using Core.Models.Entities.Product;
using Core.Models.Entities.ProductPicture;

namespace AxionTech.WEB.GetApi;

public class ProductPictureApi
{
    private readonly HttpClient _httpClient;
    public ProductPictureApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public List<ProductPictureResponseModel> List()
    {
        var responseProductPicture = _httpClient.GetFromJsonAsync<APIResponseDTO<List<ProductPictureResponseModel>>>("ProductPicture/List").Result;
        return responseProductPicture.Data;
    }

    public bool Create(CreateProductPictureRequestModel request)
    {
        var response = _httpClient.PostAsJsonAsync($"ProductPicture/Create", request).Result;

        if (response.IsSuccessStatusCode == true)
        {
            return true;
        }
        return false;


    }

}
