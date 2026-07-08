using AxionTech.WEB.GetApi;
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
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ProductController(HttpClient httpClient, ProductApi productApi, CategoryApi categoryApi, ProductPriceApi productPriceApi, ProductPictureApi productPictureApi, ProductDocumentApi productDocumentApi, IHttpContextAccessor httpContextAccessor ) : base(httpClient, httpContextAccessor)
    {
        _productApi = productApi;
        _categoryApi = categoryApi;
        _productPriceApi = productPriceApi;
        _productPictureApi = productPictureApi;
        _productDocumentApi = productDocumentApi;
        _httpContextAccessor = httpContextAccessor;
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

       var  cookieList = _httpContextAccessor.HttpContext.Request.Cookies["guestCart"];

        if (cookieList != null)
        {
            var listCookie = CookieProductList();
            AddToCartWithCookie(listCookie);
            ViewBag.cookieData = listCookie;

        }
        ViewBag.category = _categoryApi.List();

        ViewBag.AllPrices = _productPriceApi.List();
        return View(_productApi.List());
    }
    
    public IActionResult Detail(int Id)
    {
        ViewBag.category = _categoryApi.List();
        /*
        var getProduct=_productApi.GetById(Id);
        //ViewBag.productPrice = _productPriceApi.List();
        //ViewBag.productPicture = _productPictureApi.List();
        //ViewBag.productDocument = _productDocumentApi.List();  
        yukardaki yapıları ViewBag ile tek tek göndermek yerine, ProductDetailResponseModel adında bir class oluşturup, içine istediğimiz dataları atarak tek bir Model (ProductDetailResponseModel) ile gönderebiliriz.
         */
        var price= _productPriceApi.List().Where(x => x.ProductId == Id).ToList();

        var getProductDetail = new ProductDetailResponseModel
        {
            ProductDetail = _productApi.GetById(Id),
            ProductPicture = _productPictureApi.List().Where(k=>k.ProductId==Id).ToList(),
            //ProductDocument = _productDocumentApi.List().Where(k => k.ProductId == Id).ToList(),
            ProductDocument =null,
           ProductPrice = price,

        };

        return View(getProductDetail);
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
