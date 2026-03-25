using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductPriceController : BaseAPIController
{
    private readonly IProductPriceService _productPriceService;

    public ProductPriceController(IProductPriceService productPriceService)
    {
        _productPriceService = productPriceService;
    }

    [HttpGet("GetPriceByProductId")]
    public IActionResult GetPriceByProductId(int Id)
    {
       var  getPrice= _productPriceService.GetByProductId(Id);
        return ResultAPI(getPrice);//json formatında döner
    }
 
}
