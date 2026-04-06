using AxionTech.WEB.GetApi;
using Core.Models.Entities.Cart;
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

        if (carts == null)
        {
            return View(new List<Core.Models.Entities.Cart.CartResponseModel>());
        }

        foreach (var cart in carts)
        {
            try
            {
                cart.Items = _cartItemApi.GetByCartId(cart.Id) ?? new List<Core.Models.Entities.CartItem.CartItemResponseModel>();
            }
            catch
            {
                cart.Items = new List<Core.Models.Entities.CartItem.CartItemResponseModel>();
            }
        }

        return View(carts);
    }
    public IActionResult Detail(int id)
    {
        var cart = _cartApi.GetByCartId(id);

        var cartItems = _cartItemApi.GetByCartId(id);

        var getCartDetail = new CartDetailResponseModel
        {
            CartDetail = cart,
            Items = cartItems
        };

        return View(getCartDetail);
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var cart = _cartApi.GetByCartId(id);
        return View(cart);
    }
    [ActionName("Delete")]
    [HttpPost]
    public IActionResult DeleteCart(DeleteCartRequestModel request)
    {
        var deleteCart = _cartApi.Delete(request);
        if (deleteCart)
        {
            return RedirectToAction("List");
        }

        return View();
    }
    public IActionResult Update(int id)
    {
        var cart = _cartApi.GetByCartId(id);
        var cartItems = _cartItemApi.GetByCartId(id);

        cart.Items = cartItems;

        return View(cart);
    }
    [HttpPost]
    public IActionResult Update(UpdateCartRequestModel request)
    {
        var updateCart = _cartApi.Update(request);

        if (updateCart)
        {
            return RedirectToAction("List");
        }

        return View();
    }
}
