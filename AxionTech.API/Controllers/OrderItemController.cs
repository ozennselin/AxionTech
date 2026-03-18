using Business.Service.Interfaces;
using Core.Models.Entities.OrderItem;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemController : BaseAPIController
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }
    [HttpPost("Create")]
    public IActionResult Create(CreateOrderItemRequestModel request)
    {
        _orderItemService.Create(request);
        return Ok();
    }

    [HttpPut("Update")]
    public IActionResult Update(UpdateOrderItemRequestModel request)
    {
        _orderItemService.Update(request);
        return Ok();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(DeleteOrderItemRequestModel request)
    {
        _orderItemService.Delete(request);
        return Ok();
    }

    [HttpGet("GetByOrderId")]
    public IActionResult GetByOrderId(int orderId)
    {
        var result = _orderItemService.GetByOrderId(orderId);
        return Ok(result);
    }

 
}
