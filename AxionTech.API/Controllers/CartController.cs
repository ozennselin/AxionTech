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
        var result=_cartService.Create(request);
        return ResultAPI(result);
    }

    [HttpPut]
    public IActionResult Update(UpdateCartRequestModel request)
    {
        var result = _cartService.Update(request);
        return ResultAPI(result);
    }

    [HttpDelete]
    public IActionResult Delete(DeleteCartRequestModel request)
    {
        var result = _cartService.Delete(request);
        return ResultAPI(result);
    }

    [HttpGet("{cartId}")]
    public IActionResult GetByCartId(int cartId)
    {
        var result = _cartService.GetById(cartId);
        return ResultAPI(result);
    }
    [HttpGet("List")]
    public IActionResult List()
    {
        var result = _cartService.List();
        return ResultAPI(result);

    }
}

