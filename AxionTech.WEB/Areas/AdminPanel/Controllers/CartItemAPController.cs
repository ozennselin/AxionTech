using AxionTech.WEB.GetApi;
using Core.Dtos;
using Core.Models.Entities.CartItem;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class CartItemAPController:Controller
{
    private readonly CartItemApi _cartItemApi;

    public CartItemAPController(CartItemApi cartItemApi)
    {
        _cartItemApi = cartItemApi;
    }
     public IActionResult List()
    {
        var cartItems = _cartItemApi.List();
        return View(cartItems);
    }
  
}
