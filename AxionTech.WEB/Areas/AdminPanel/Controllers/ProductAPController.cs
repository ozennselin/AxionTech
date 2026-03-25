using AxionTech.WEB.GetApi;
using Core.Models.Entities.Product;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class ProductAPController : Controller
{
    private readonly ProductApi _productApi;
    private readonly ProductPriceApi _productPriceApi;
    private readonly ProductPictureApi _productPictureApi;
    private readonly ProductDocumentApi _productDocumentApi;

    public ProductAPController(ProductApi productApi, ProductPriceApi productPriceApi, ProductPictureApi productPictureApi, ProductDocumentApi productDocumentApi)
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
            return RedirectToAction("List");
        }
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

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            var fileName = Path.GetFileName(file.FileName);

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "picture");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var path = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        return RedirectToAction("Update");
    }
}

