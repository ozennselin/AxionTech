using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;


namespace AxionTech.WEB.Controllers;

public class CartController : Controller
{
    private readonly CartApi _cartApi;

    public CartController(CartApi cartApi)
    {
        _cartApi = cartApi;
    }

    public IActionResult List()
    {
        var list = _cartApi.List();
        return View(list);
    }
}
