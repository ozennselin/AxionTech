using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;


public class CartAPController : Controller
{
    private readonly CartApi _cartApi;
    private readonly CartItemApi _cartItemApi;
    public CartAPController(CartApi cartApi, CartItemApi cartItemApi)
    {
        _cartApi = cartApi;
        _cartItemApi = cartItemApi;
    }

    public IActionResult List()
    {
        var carts = _cartApi.List();

        foreach (var cart in carts)
        {
            cart.Items = _cartItemApi.GetByCartId(cart.Id);
        }

        return View(carts);
    }
}
