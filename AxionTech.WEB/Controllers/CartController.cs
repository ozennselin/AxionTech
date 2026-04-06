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

  // public IActionResult AddCart(int id)
    public JsonResult AddCart(int id)//giriş(Açık)
    {
        var result=_cartApi.AddCart(id);
        //sepet için cookie işlemi, session işlemi  yapılabilir. Biz DB ye ekleme işlemi yaptık.

        return Json(new { success = true ,data=result});//bitiş-Kapatılacak
    }
}
