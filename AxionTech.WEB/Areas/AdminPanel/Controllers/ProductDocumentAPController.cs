using AxionTech.WEB.GetApi;
using Core.Models.Entities.ProductDocument;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
public class ProductDocumentAPController : Controller
{
    private readonly ProductDocumentApi _productDocumentApi;

    public ProductDocumentAPController(ProductDocumentApi productDocumentApi)
    {
        _productDocumentApi = productDocumentApi;
    }

    [HttpPost]
    public async Task<IActionResult> UploadDocument(IFormFile file, int productId)
    {
        if (file == null || file.Length == 0) return Json(new { success = false, message = "Dosya seçilmedi." });

        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "documents");

        if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

        string filePath = Path.Combine(uploadFolder, uniqueFileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        var createDocumentRequest = new CreateProductDocumentRequestModel
        {
            ProductId = productId,
            Url = "/documents/" + uniqueFileName,
            FileName = file.FileName,
            FileType = Path.GetExtension(file.FileName)
        };

        bool result = _productDocumentApi.Create(createDocumentRequest);

        return Json(new
        {
            success = result,
            message = result ? "Başarılı" : "API Hatası: Veritabanına kaydedilemedi.",
            data = createDocumentRequest
        });
    }

    [HttpPost]
    public IActionResult DeleteDocument(int id)
    {
        var result = _productDocumentApi.Delete(id);

        if (result)
        {
            return Json(new { success = true, message = "Döküman silindi." });
        }
        return Json(new { success = false, message = "Döküman silinemedi." });
    }
}