using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.ProductPrice;
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

    [HttpGet("List")]
    public IActionResult List()
    {
        var list = _productPriceService.List();
        return ResultAPI(list);
    }

    [HttpGet("GetByProductId/{id}")]
    public IActionResult GetByProductId(int id)
    {
        var price = _productPriceService.GetByProductId(id);
        return ResultAPI(price);
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateProductPriceRequestModel request)
    {
        var result = _productPriceService.Create(request);
        return ResultAPI(result);
    }

    [HttpPost("Update")]
    public IActionResult Update([FromBody] UpdateProductPriceRequestModel request)
    {
        var result = _productPriceService.Update(request);
        return ResultAPI(result);
    }

    [HttpPost("Delete")]
    public IActionResult Delete([FromBody] DeleteProductPriceRequestModel request)
    {
        var result = _productPriceService.Delete(request);
        return ResultAPI(result);
    }
}