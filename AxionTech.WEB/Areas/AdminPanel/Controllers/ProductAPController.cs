using AxionTech.WEB.GetApi;
using Core.Dtos;
using Core.Models.Entities.Category;
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
    private readonly CategoryApi _categoryApi;

    public static int productId;

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
            Category = _categoryApi.List()

        };

        return View(getProductDetail);
    }

    [HttpPost]
    public IActionResult Create(CreateProductRequestModel request)
    {
        bool result = _productApi.Create(request);
        if (result)
        {
            return RedirectToAction("List");
        }
        ViewBag.error = "Ürün oluşturulurken bir hata oluştu.";
        var getProductDetail = new ProductCreateUpdateResponseModel
        {
            ProductDetail = null,
            ProductPicture = _productPictureApi.List().Where(k => k.ProductId == request.Id).ToList(),
            //ProductDocument = _productDocumentApi.List().Where(k=>k.ProductId==Id).ToList(),
            ProductDocument = null,
            ProductPrice = null,
            Category = _categoryApi.List()

        };
        return View(getProductDetail);
    }
    public IActionResult Update(int Id)
    {
        productId = Id;
        var getProductAllDetail = new ProductCreateUpdateResponseModel
        {
            ProductDetail = _productApi.GetById(Id),
            ProductPicture = _productPictureApi.List().Where(k => k.ProductId == Id).ToList(),
            //ProductDocument = _productDocumentApi.List().Where(k=>k.ProductId==Id).ToList(),
            ProductDocument = null,
            Category = _categoryApi.List()

        };
        return View(getProductAllDetail);
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
        //resim db y ekayıt işlemi brda yapılacak
        if (file == null || file.Length == 0)
        {
            return Json(new { success = false, message = "Dosya seçilmedi." });
        }

        //resme benzersiz isim verme işlemi
        var uniquePictureName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "picture");
        string filePath = Path.Combine(uploadFolder, uniquePictureName);

        //Fizikse Kayıt
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
        //Resmi DB ye  kaydetme işlemi
        var createProductPictureRequest = new CreateProductPictureRequestModel
        {
            ProductId = productId, //Bu değeri dinamik olarak belirlemeniz gerekecek
            Url = "/picture/" + uniquePictureName,
            //IsMain = false,//trigger
            DisplayOrder = 0,//trigger
            Name = uniquePictureName,
            OrjinalName = file.FileName
        };
        bool result = _productPictureApi.Create(createProductPictureRequest);

        if (!result)
        {
            return Json(new { success = false, message = "Resim veritabanına kaydedilirken bir hata oluştu." });
        }

        return Json(new { success = true, path = createProductPictureRequest.Url });
    }
}

