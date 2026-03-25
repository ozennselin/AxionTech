using Business.Service.Interfaces;
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

}
