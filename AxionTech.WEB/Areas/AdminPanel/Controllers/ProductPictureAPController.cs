using AxionTech.WEB.GetApi;
using Core.Models.Entities.ProductPicture;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
public class ProductPictureAPController : Controller
{
    private readonly ProductPictureApi _productPictureApi;

    public ProductPictureAPController(ProductPictureApi productPictureApi)
    {
        _productPictureApi = productPictureApi;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file, int productId)
    {
        if (file == null || file.Length == 0)
        {
            return Json(new { success = false, message = "Dosya seçilmedi." });
        }

        var uniquePictureName = Guid.NewGuid().ToString() + "_" + file.FileName;

        var createProductPictureRequest = new CreateProductPictureRequestModel
        {
            ProductId = productId,
            Url = "/picture/" + uniquePictureName,
            DisplayOrder = 0,
            Name = uniquePictureName,
            OrjinalName = file.FileName
        };

        bool result = _productPictureApi.Create(createProductPictureRequest);

        if (!result)
        {
            return Json(new { success = false, message = "Bu ürün için aynı isimli bir resim zaten mevcut!" });
        }

        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "picture");
        string filePath = Path.Combine(uploadFolder, uniquePictureName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return Json(new { success = true, data = createProductPictureRequest });
    }

    [HttpPost]
    public IActionResult DeletePicture(int id)
    {
        var getPicture = _productPictureApi.GetById(id);
        if (getPicture == null)
        {
            return Json(new { success = false, message = "Resim bulunamadı." });
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", getPicture.Url.TrimStart('/'));
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
        }

        bool result = _productPictureApi.Delete(new DeleteProductPictureRequestModel { Id = id });
        if (!result)
        {
            return Json(new { success = false, message = "Resim veritabanından silinirken bir hata oluştu." });
        }
        return Json(new { success = true, message = "Resim başarıyla silindi.", data = getPicture });
    }
}