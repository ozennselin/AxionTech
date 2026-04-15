using Business.Service;
using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Product;
using Core.Models.Entities.ProductPicture;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductPictureController : BaseAPIController
{
    private readonly IProductPictureService _productPictureService;
    public ProductPictureController(IProductPictureService productPictureService)
    {
        _productPictureService = productPictureService;
    }
   
    [HttpGet("GetByProductId")]
    public IActionResult GetByProductId(int id)
    {
        var getPicture = _productPictureService.GetByProductId(id);
        return ResultAPI(getPicture);
    }

    [HttpGet("List")]
    public IActionResult List()
    {
        var list = _productPictureService.List();
        return ResultAPI(list);
    }


    [HttpPost("Create")]
    public IActionResult Create(CreateProductPictureRequestModel request)
    {
        var result = _productPictureService.Create(request);

        if (result == ResponseMessageEnum.Success)
        {
            return ResultAPI(result);
        }
        return BadRequest(new { Message = ResponseMessageEnum.NotExist, ErrorCode = result });
    }

    [HttpPost("Delete")]
    public IActionResult Delete(int Id)
    {
        var getPicture = _productPictureService.GetById(Id);
        if (getPicture == null)
        {
            return BadRequest(new { Message = ResponseMessageEnum.Exist, ErrorCode = "Picture not fond" });
        }
        var request = _productPictureService.Delete(new DeleteProductPictureRequestModel { Id = Id });
        return ResultAPI(request);
    }


    [HttpGet("GetById")]
    public IActionResult GetById(int id)
    {
        var getPicture = _productPictureService.GetById(id);
        return ResultAPI(getPicture);
    }

    [HttpPost("Upload")]
    public IActionResult Upload(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Dosya seçilmedi.");
            }

            var extension = Path.GetExtension(file.FileName);
            var newFileName = Guid.NewGuid().ToString() + extension;

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Ok(new
            {
                Url = "/uploads/" + newFileName,
                Name = newFileName,
                OrjinalName = file.FileName
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
