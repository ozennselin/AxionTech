using AxionTech.WEB.GetApi;
using Core.Dtos;
using Core.Models.Entities.Category;
using Core.Models.Entities.Product;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class ProductAPController : Controller
{
    private readonly ProductApi _productApi;
    private readonly ProductPriceApi _productPriceApi;
    private readonly ProductPictureApi _productPictureApi;
    private readonly ProductDocumentApi _productDocumentApi;
    private readonly CategoryApi _categoryApi;

    public ProductAPController(ProductApi productApi, ProductPriceApi productPriceApi, ProductPictureApi productPictureApi, ProductDocumentApi productDocumentApi, CategoryApi categoryApi = null)
    {
        _productApi = productApi;
        _productPriceApi = productPriceApi;
        _productPictureApi = productPictureApi;
        _productDocumentApi = productDocumentApi;
        _categoryApi = categoryApi;
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
        var getProductDetail = new ProductCreateUpdateResponseModel
        {
            ProductDetail = null,
            //ProductPicture = _productPictureApi.List().Where(k=>k.ProductId==Id).ToList(),
            //ProductDocument = _productDocumentApi.List().Where(k=>k.ProductId==Id).ToList(),
            ProductDocument = null,
            ProductPicture = null,
            ProductPrice = null,
            Category= _categoryApi.List()

        };

        return View(getProductDetail);
    }

    [HttpPost]
    public IActionResult Create(CreateProductRequestModel request)
    {
      bool result=  _productApi.Create(request);
        if (result)
        {
            return RedirectToAction("List");
        }
        ViewBag.error = "Ürün oluşturulurken bir hata oluştu.";
        var getProductDetail = new ProductCreateUpdateResponseModel
        {
            ProductDetail = null,
            //ProductPicture = _productPictureApi.List().Where(k=>k.ProductId==Id).ToList(),
            //ProductDocument = _productDocumentApi.List().Where(k=>k.ProductId==Id).ToList(),
            ProductDocument = null,
            ProductPicture = null,
            ProductPrice = null,
            Category = _categoryApi.List()

        };
        return View(getProductDetail);
    }
    public IActionResult Update(int Id)
    {
        var product = _productApi.GetById(Id);
        return View(product);
    }

    [HttpPost]
    public IActionResult Update(UpdateProductRequestModel request)
    {
        var updateProduct = _productApi.Update(request);
        if (updateProduct)
        {
            return RedirectToAction("List");}
        return View();
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var product = _productApi.GetById(id);
       
        return View(product);
    }

    [ActionName("Delete")]
    [HttpPost]
    public IActionResult DeleteProduct(DeleteProductRequestModel request)
    {
        var updateProduct = _productApi.Delete(request);
        if (updateProduct)
        {
            return RedirectToAction("List");
        }
        return View();
    }
}

