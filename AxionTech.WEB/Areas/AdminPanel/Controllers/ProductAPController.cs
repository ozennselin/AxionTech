using AxionTech.WEB.GetApi;
using Azure.Core;
using Core.Dtos;
using Core.Enums;
using Core.Models.Entities.Category;
using Core.Models.Entities.Product;
using Core.Models.Entities.ProductDocument;
using Core.Models.Entities.ProductPicture;
using Core.Models.Entities.ProductPrice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]

public class ProductAPController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var adminSession = HttpContext.Session.GetString("AdminPanelUserName");

        if (string.IsNullOrEmpty(adminSession))
        {
            context.Result = new RedirectToActionResult(
                "Login",
                "AdminLoginAP",
                new { area = "AdminPanel" });
        }

        base.OnActionExecuting(context);
    }
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

    #region Product    
    public IActionResult List()
    {
        var list = _productApi.List();
        return View(list);
    }

    public IActionResult Detail(int id)
    {
        var product = _productApi.GetById(id);

        var price = _productPriceApi.List().Where(k => k.ProductId == id).ToList();

        var getProductDetail = new ProductDetailResponseModel
        {
            ProductDetail = product,
            //ProductPicture = _productPictureApi.List().Where(k=>k.ProductId==Id).ToList(),
            //ProductDocument = _productDocumentApi.List().Where(k=>k.ProductId==Id).ToList(),
            ProductPicture = _productPictureApi.List().Where(k => k.ProductId == id).ToList(),
            ProductDocument = _productDocumentApi.List(id),
            ProductPrice = price,

        };
        return View(getProductDetail);
    }

    public IActionResult Create()
    {
        var getProductDetail = new ProductCreateUpdateResponseModel
        {
            ProductDetail = new ProductResponseModel(),
            //ProductPicture = _productPictureApi.List().Where(k=>k.ProductId==Id).ToList(),
            //ProductDocument = _productDocumentApi.List().Where(k=>k.ProductId==Id).ToList(),
            ProductPrice = new List<ProductPriceResponseModel>(),
            ProductPicture = new List<ProductPictureResponseModel>(),
            ProductDocument = new List<ProductDocumentResponseModel>(),
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
        request.Message = ResponseMessageEnum.Error.ToString();

        var getProductDetail = new ProductCreateUpdateResponseModel
        {
            Message = request.Message,
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
        //productId = Id;
        //var product = _productApi.GetById(Id);
        //var picture = _productPictureApi.List().Where(k => k.ProductId == Id);

        //var getProductAllDetail = new ProductCreateUpdateResponseModel
        //{
        //    ProductDetail = product,
        //    ProductPicture = picture.ToList(),
        //    ProductPrice= null,
        //    ProductDocument = null,
        //    Category = null//_categoryApi.List()

        //};
        //return View(getProductAllDetail);

        productId = Id;
        var getProductAllDetail = new ProductCreateUpdateResponseModel
        {
            ProductDetail = _productApi.GetById(Id),
            ProductPicture = _productPictureApi.List().Where(k => k.ProductId == Id).ToList(),
            //ProductDocument = _productDocumentApi.List().Where(k=>k.ProductId==Id).ToList(),
            ProductDocument = _productDocumentApi.List(Id),
            ProductPrice = _productPriceApi.List().Where(k => k.ProductId == Id).ToList(),
            Category =_categoryApi.List()

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

    #endregion

    //#region Picture    

    //[HttpPost]
    //public async Task<IActionResult> Upload(IFormFile file)
    //{
    //    //resim db y ekayıt işlemi brda yapılacak
    //    if (file == null || file.Length == 0)
    //    {
    //        return Json(new { success = false, message = "Dosya seçilmedi." });
    //    }

    //    //resme benzersiz isim verme işlemi
    //    var uniquePictureName = Guid.NewGuid().ToString() + "_" + file.FileName;

    //    //Resmi DB ye  kaydetme işlemi için request hazırlanıyor
    //    var createProductPictureRequest = new CreateProductPictureRequestModel
    //    {
    //        ProductId = productId, //Bu değeri dinamik olarak belirlemeniz gerekecek
    //        Url = "/picture/" + uniquePictureName,
    //        //IsMain = false,//trigger
    //        DisplayOrder = 0,//trigger
    //        Name = uniquePictureName,
    //        OrjinalName = file.FileName
    //    };

    //    // Önce DB kaydı deneniyor (Service içindeki kontrol burada çalışır)
    //    bool result = _productPictureApi.Create(createProductPictureRequest);

    //    if (!result)
    //    {
    //        // Eğer servis "Aynı isimli resim var" diyerek false dönerse fiziksel kayda hiç geçmiyoruz
    //        return Json(new { success = false, message = "Bu ürün için aynı isimli bir resim zaten mevcut!" });
    //    }

    //    //Fizikse Kayıt (DB kaydı başarılıysa buraya geçer)
    //    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "picture");
    //    string filePath = Path.Combine(uploadFolder, uniquePictureName);

    //    using (var fileStream = new FileStream(filePath, FileMode.Create))
    //    {
    //        await file.CopyToAsync(fileStream);
    //    }

    //    return Json(new { success = true, data = createProductPictureRequest });
    //}

    //[HttpPost]
    //public IActionResult DeletePicture(int id)
    //{
    //    var getPicture = _productPictureApi.GetById(id);
    //    if (getPicture == null)
    //    {
    //        return Json(new { success = false, message = "Resim bulunamadı." });
    //    }

    //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", getPicture.Url.TrimStart('/'));
    //    if (System.IO.File.Exists(filePath))
    //    {
    //        System.IO.File.Delete(filePath);
    //    }

    //    bool result = _productPictureApi.Delete(new DeleteProductPictureRequestModel { Id = id });
    //    if (!result)
    //    {
    //        return Json(new { success = false, message = "Resim veritabanından silinirken bir hata oluştu." });
    //    }
    //    return Json(new { success = true, message = "Resim başarıyla silindi.", data = getPicture });
    //}


    //#endregion  

    //#region Document


    //[HttpPost]
    //public async Task<IActionResult> UploadDocument(IFormFile file, int productId)
    //{
    //    if (file == null || file.Length == 0) return Json(new { success = false, message = "Dosya seçilmedi." });

    //    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
    //    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "documents");

    //    if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

    //    string filePath = Path.Combine(uploadFolder, uniqueFileName);
    //    using (var fileStream = new FileStream(filePath, FileMode.Create))
    //    {
    //        await file.CopyToAsync(fileStream);
    //    }

    //    var createDocumentRequest = new Core.Models.Entities.ProductDocument.CreateProductDocumentRequestModel
    //    {
    //        ProductId = productId,
    //        Url = "/documents/" + uniqueFileName, 
    //        FileName = file.FileName,
    //        FileType = Path.GetExtension(file.FileName)
    //    };

    //    bool result = _productDocumentApi.Create(createDocumentRequest);

    //    return Json(new
    //    {
    //        success = result,
    //        message = result ? "Başarılı" : "API Hatası: Veritabanına kaydedilemedi.",
    //        data = createDocumentRequest
    //    });
    //}

    //[HttpPost]
    //public IActionResult DeleteDocument(int id)
    //{
    //    var result = _productDocumentApi.Delete(id);

    //    if (result)
    //    {
    //        return Json(new { success = true, message = "Döküman silindi." });
    //    }
    //    return Json(new { success = false, message = "Döküman silinemedi." });
    //}
   
    //#endregion

    //[HttpPost]
    //public IActionResult AddPrice(decimal price, string description, int productId)
    //{
    //    var request = new CreateProductPriceRequestModel
    //    {
    //        ProductId = productId,
    //        Price = price,
    //        Description = description
    //    };
    //    var result = _productPriceApi.Create(request);
    //    return Json(new { success = (result == ResponseMessageEnum.Success) });
    //}

    //[HttpPost]
    //public IActionResult DeletePrice(int id)
    //{
    //    var result = _productPriceApi.Delete(new DeleteProductPriceRequestModel { Id = id });
    //    return Json(new { success = (result == ResponseMessageEnum.Success) });
    //}

}

