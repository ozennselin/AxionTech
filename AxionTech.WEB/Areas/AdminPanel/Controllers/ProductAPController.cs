using AxionTech.WEB.GetApi;
using Core.Models.Entities.Product;
using Core.Models.Entities.ProductPicture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class ProductAPController : Controller
{
    private readonly ProductApi _productApi;
    private readonly ProductPriceApi _productPriceApi;
    private readonly ProductPictureApi _productPictureApi;
    private readonly ProductDocumentApi _productDocumentApi;
    private readonly IWebHostEnvironment _environment;

    public ProductAPController(ProductApi productApi, ProductPriceApi productPriceApi, ProductPictureApi productPictureApi, ProductDocumentApi productDocumentApi, IWebHostEnvironment environment)
    {
        _productApi = productApi;
        _productPriceApi = productPriceApi;
        _productPictureApi = productPictureApi;
        _productDocumentApi = productDocumentApi;
        _environment = environment;
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
        if (file == null || file.Length == 0)
            return BadRequest("Dosya seçilmedi.");

        // 1. Dosya Yolu Hazırlama
        string uploadsFolder = Path.Combine(_environment.WebRootPath, "~/picture/");
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        // Benzersiz dosya adı oluşturma
        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        // 2. Fiziksel Kayıt
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        // 3. Veritabanı Kaydı
        var productImage = new CreateProductPictureRequestModel
        {
            FileName = uniqueFileName,
            FilePath = "/uploads/products/" + uniqueFileName,
            CreateDate = DateTime.Now
        };

        //_context.ProductImages.Add(productImage);
        //await _context.SaveChangesAsync();

        return Json(new { success = true, path = productImage.FilePath });
    }
}

