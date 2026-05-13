using AxionTech.WEB.GetApi;
using Core.Dtos;
using Core.Models.Entities.CartItem;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]

public class CartItemAPController:Controller
{
    private readonly CartItemApi _cartItemApi;

    public CartItemAPController(CartItemApi cartItemApi)
    {
        _cartItemApi = cartItemApi;
    }
     public IActionResult List()
    {
        var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
        var cartItems = _cartItemApi.List(userId);
        return View(cartItems);
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
        var cartItems = _cartItemApi.List(userId);
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
