using Business.Service;
using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Product;
using Core.Models.Entities.ProductPicture;
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
    public IActionResult GetByProductId(int Id)
    {
        var getPicture = _productPictureService.GetByProductId(Id);
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

        if (result== ResponseMessageEnum.Success)
        {
            return ResultAPI(result);
        }
        return BadRequest(new { Message = ResponseMessageEnum.Exist, ErrorCode = result });
    }
}
