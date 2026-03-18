using Business.Service.Interfaces;
using Core.Models.Entities.Order;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : BaseAPIController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("List")]
    public IActionResult List()
    {
        var result = _orderService.List();
        return Ok(result);
    }
    [HttpPost("Create")]
    public IActionResult Create(CreateOrderRequestModel request)
    {
        _orderService.Create(request);
        return Ok();
    }
    [HttpPut("Update")]
    public IActionResult Update(UpdateOrderRequestModel request)
    {
        _orderService.Update(request);
        return Ok();
    }
    [HttpDelete("Delete")]
    public IActionResult Delete(DeleteOrderRequestModel request)
    {
        _orderService.Delete(request);
        return Ok();
    }

}
