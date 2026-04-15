using Core.Dtos;
using Core.Enums;
using Core.Models.Entities.ProductPrice;
using Newtonsoft.Json;
using System.Text;

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
    public List<ProductPriceResponseModel> List()
    {
        var responseProductPrice = _httpClient.GetAsync("ProductPrice/List").Result;

        var content = responseProductPrice.Content.ReadAsStringAsync();

        if (content.IsCompletedSuccessfully)
        {
            var response = JsonConvert.DeserializeObject<APIResponseDTO<List<ProductPriceResponseModel>>>(content.Result.ToString());
            return response.Data;
        }
        return new List<ProductPriceResponseModel>();
    }
    public ResponseMessageEnum Create(CreateProductPriceRequestModel request)
    {
        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var responseProductPrice = _httpClient.PostAsync("ProductPrice/Create", content).Result;

        var resultContent = responseProductPrice.Content.ReadAsStringAsync();

        if (resultContent.IsCompletedSuccessfully)
        {
            var response = JsonConvert.DeserializeObject<APIResponseDTO<ResponseMessageEnum>>(resultContent.Result.ToString());
            return response.Data;
        }

        return ResponseMessageEnum.Error;
    }
    public ResponseMessageEnum Update(UpdateProductPriceRequestModel request)
    {
        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var responseProductPrice = _httpClient.PostAsync("ProductPrice/Update", content).Result;

        var resultContent = responseProductPrice.Content.ReadAsStringAsync();

        if (resultContent.IsCompletedSuccessfully)
        {
            var response = JsonConvert.DeserializeObject<APIResponseDTO<ResponseMessageEnum>>(resultContent.Result.ToString());
            return response.Data;
        }

        return ResponseMessageEnum.Error;
    }
    public ResponseMessageEnum Delete(DeleteProductPriceRequestModel request)
    {
        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var responseProductPrice = _httpClient.PostAsync("ProductPrice/Delete", content).Result;

        var resultContent = responseProductPrice.Content.ReadAsStringAsync();

        if (resultContent.IsCompletedSuccessfully)
        {
            var response = JsonConvert.DeserializeObject<APIResponseDTO<ResponseMessageEnum>>(resultContent.Result.ToString());
            return response.Data;
        }

        return ResponseMessageEnum.Error;
    }
}
