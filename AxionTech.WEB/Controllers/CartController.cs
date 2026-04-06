using AxionTech.WEB.GetApi;
using Core.Models.Entities.Cart;
using Microsoft.AspNetCore.Mvc;


namespace AxionTech.WEB.Controllers;

public class CartController : BaseController
{
    private readonly CartApi _cartApi;
    private readonly CategoryApi _categoryApi;

    public CartController(CartApi cartApi, HttpClient httpClient, CategoryApi categoryApi = null) : base(httpClient)
    {
        _cartApi = cartApi;
        _categoryApi = categoryApi;
    }

    public IActionResult List()
    {
        ViewBag.category = _categoryApi.List();
        var list = _cartApi.List();
        return View(list);
    }

  // public IActionResult AddCart(int id)
    public JsonResult AddCart(int id)//giriş(Açık)
    {
        CreateCartRequestModel model = new CreateCartRequestModel();
        model.ProductId = id;
        model.UserId = 1;//session işlemi yapılabilir. Biz şimdilik 1 verdik.
        var result=_cartApi.AddCart(model);
        //sepet için cookie işlemi, session işlemi  yapılabilir. Biz DB ye ekleme işlemi yaptık.

        return Json(new { success = true ,data=result});//bitiş-Kapatılacak
    }
}
