using AxionTech.WEB.GetApi;
using Core.Models.Entities.Product;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class ProductAPController : Controller
{
    private readonly ProductApi _productApi;
        private readonly ProductPriceApi _productPriceApi;
        private readonly ProductPictureApi _productPictureApi;
        private readonly ProductDocumentApi _productDocumentApi;

    public ProductAPController(ProductApi productApi, ProductPriceApi productPriceApi = null, ProductPictureApi productPictureApi = null, ProductDocumentApi productDocumentApi = null)
    {
        _productApi = productApi;
        _productPriceApi = productPriceApi;
        _productPictureApi = productPictureApi;
        _productDocumentApi = productDocumentApi;
    }

    public IActionResult List()
    {
        var list = _productApi.List();
        return View(list);
    }

    public IActionResult Detail(int id)
    {
        var product = _productApi.GetById(id);

        var price = _productPriceApi.GetPriceByProductId(id);

        var getProductDetail = new ProductDetailResponseModel
        {
            ProductDetail = product,
            //ProductPicture = _productPictureApi.List().Where(k=>k.ProductId==Id).ToList(),
            //ProductDocument = _productDocumentApi.List().Where(k=>k.ProductId==Id).ToList(),
            ProductDocument = null,
            ProductPicture = null,
            ProductPrice = price,

        };
        return View(getProductDetail);
    }


    public IActionResult Create()
    {
        return View();
    }
}

