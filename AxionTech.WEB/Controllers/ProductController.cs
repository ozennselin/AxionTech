using AxionTech.WEB.GetApi;
using Core.Dtos;
using Core.Models.Entities.Category;
using Core.Models.Entities.Product;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class ProductController : BaseController
{
    private readonly ProductApi _productApi;
    private readonly CategoryApi _categoryApi;
    private readonly ProductPriceApi _productPriceApi;
    private readonly ProductPictureApi _productPictureApi;
    private readonly ProductDocumentApi _productDocumentApi;
    public ProductController(HttpClient httpClient, ProductApi productApi, CategoryApi categoryApi, ProductPriceApi productPriceApi, ProductPictureApi productPictureApi, ProductDocumentApi productDocumentApi) : base(httpClient)
    {
        _productApi = productApi;
        _categoryApi = categoryApi;
        _productPriceApi = productPriceApi;
        _productPictureApi = productPictureApi;
        _productDocumentApi = productDocumentApi;
    }

    public IActionResult List()
    {
        #region API bağlantıları, dataların çekilmesi dosya,class taşınmadan önce
        //var uriApiAdres = "https://localhost:7162/api/Category/List";
        //var response = _httpClient.GetFromJsonAsync<APIResponseDTO<List<CategoryResponseModel>>>(uriApiAdres).Result;
        //ViewBag.category = response.Data;
        ////-----------------------
        ////ürün list işlemleri
        //var uriApiAdresPro = "https://localhost:7162/api/Product/List";
        //var responsePro = _httpClient.GetFromJsonAsync<APIResponseDTO<List<ProductResponseModel>>>(uriApiAdresPro).Result;   
        #endregion
        ViewBag.category=_categoryApi.List();
        return View(_productApi.List());
    }
    
    public IActionResult Detail(int Id)
    {
        var productDetail=_productApi.Detail(Id);
        ViewBag.category = _categoryApi.List();
        ViewBag.productPrice = _productPriceApi.List();
        ViewBag.productPicture = _productPictureApi.List();
        ViewBag.productDocument = _productDocumentApi.List();
        return View(productDetail);
    }
    public IActionResult Cart()
    {
        return View();
    }
    public IActionResult Checkout()
    {
        return View();
    }
    public IActionResult Wishlist()
    {
        return View();
    }

}
