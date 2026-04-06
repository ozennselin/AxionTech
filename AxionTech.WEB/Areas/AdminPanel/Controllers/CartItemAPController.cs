using AxionTech.WEB.GetApi;
using Core.Dtos;
using Core.Models.Entities.CartItem;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var cartItems = _cartItemApi.List();
        var cartItem = cartItems.FirstOrDefault(x => x.Id == id);

        return View(cartItem);
    }
    [ActionName("Delete")]
    [HttpPost]
    public IActionResult DeleteCartItem(DeleteCartItemRequestModel request)
    {
        var result = _cartItemApi.Delete(request);

        if (result)
        {
            return RedirectToAction("List", "CartAP");
        }

        return View();
    }

}
