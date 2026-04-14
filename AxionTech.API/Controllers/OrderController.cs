using Business.Service.Interfaces;
using Core.Enums;
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
        var list = _orderService.List();
        return ResultAPI(list);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var order = _orderService.GetById(id);

        if (order == null)
            return NotFound("Order not found");

        return ResultAPI(order);
    }

    [HttpPost("UpdateStatus")]
    public IActionResult UpdateStatus(int orderId, string status)
    {
        var result = _orderService.UpdateStatus(orderId, status);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
        {
            return ResultAPI(result);
        }

        return BadRequest(new { Message = "Status update failed", ErrorCode = result });
    }
}