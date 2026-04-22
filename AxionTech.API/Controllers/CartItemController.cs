using Business.Service;
using Business.Service.Interfaces;
using Core.Models.Entities.CartItem;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartItemController : BaseAPIController
{
    private readonly ICartItemService _cartItemService;

    public CartItemController(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }

    [HttpPost]
    public IActionResult Create(CreateCartItemRequestModel request)
    {
        _cartItemService.Create(request);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(DeleteCartItemRequestModel request)
    {
        _cartItemService.Delete(request);
        return Ok();
    }

    [HttpGet("{cartId}")]
    public IActionResult GetByCartId(int cartId)
    {
        var result = _cartItemService.GetByCartId(cartId);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(UpdateCartItemRequestModel request)
    {
        _cartItemService.Update(request);
        return Ok();
    }


    [HttpGet("List")]
    public IActionResult List(int userId=1)
    {
        var result = _cartItemService.List(userId);
        return ResultAPI(result);

    }
}
