using AxionTech.WEB.GetApi;
using Core.Models.Entities.CartItem;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Components;

public class CartViewComponent : ViewComponent
{
    private readonly CartItemApi _cartItemApi;

    public CartViewComponent(CartItemApi cartItemApi)
    {
        _cartItemApi = cartItemApi;
    }

    public IViewComponentResult Invoke()
    {
        var userIdSession = HttpContext.Session.GetString("UserId");

        if (string.IsNullOrEmpty(userIdSession))
        {
            return View(new List<CartItemResponseModel>());
        }

        var userId = Convert.ToInt32(userIdSession);

        var list = _cartItemApi.List(userId);

        return View(list);
    }
}
