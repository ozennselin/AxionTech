using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : Controller
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
    
}
