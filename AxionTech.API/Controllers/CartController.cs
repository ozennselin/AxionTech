using Business.Service.Interfaces;
using Core.Models.Entities.Cart;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : BaseAPIController
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }
    [HttpPost]
    public IActionResult Create(CreateCartRequestModel request)
    {
        _cartService.Create(request);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(UpdateCartRequestModel request)
    {
        _cartService.Update(request);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(DeleteCartRequestModel request)
    {
        _cartService.Delete(request);
        return Ok();
    }

    [HttpGet("{cartId}")]
    public IActionResult GetByCartId(int cartId)
    {
        var result = _cartService.GetByCartId(cartId);
        return Ok(result);
    }
}

