using Core.Dtos;
using Core.Models.Entities.ProductPrice;
using Newtonsoft.Json;

namespace AxionTech.WEB.GetApi;

public class ProductPriceApi
{
    private readonly HttpClient _httpClient;
    public ProductPriceApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public ProductPriceResponseModel GetPriceByProductId(int productId)
    {
        var responseProductPrice = _httpClient.GetAsync($"ProductPrice/GetPriceByProductId?Id={productId}").Result;//Giden isteğin sonucunu responseProductPrice değişkenine atar.

        //Gelen cevabın içeriğini okur ve ProductPriceResponseModel türünde bir nesneye dönüştürür. Eğer içerik başarıyla okunursa, APIResponseDTO<ProductPriceResponseModel> türünde bir nesne oluşturulur ve bu nesnenin Data özelliği döndürülür. Eğer içerik okunamazsa, null döndürülür.
        var content = responseProductPrice.Content.ReadAsStringAsync();

        if (content.IsCompletedSuccessfully)
        {
            var response=JsonConvert.DeserializeObject<APIResponseDTO<ProductPriceResponseModel>>(content.Result.ToString());
            return response.Data;
        }
        return null;

    }
}
