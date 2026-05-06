using AxionTech.WEB.GetApi;
using Core.Models.Entities.Cart;
using Microsoft.AspNetCore.Mvc;


namespace AxionTech.WEB.Controllers;

public class CartController : BaseController
{
    private readonly CartApi _cartApi;
    private readonly CartItemApi _cartItemApi;
    private readonly CategoryApi _categoryApi;
    private readonly ProductApi _productApi;
    private readonly ProductPictureApi _productPictureApi;

    public CartController(CartApi cartApi, HttpClient httpClient, CategoryApi categoryApi = null, ProductApi productApi = null, CartItemApi cartItemApi = null) : base(httpClient)
    {
        _cartApi = cartApi;
        _categoryApi = categoryApi;
        _productApi = productApi;
        _cartItemApi = cartItemApi;
    }

    public IActionResult List()
    {
        var getCartItem = _cartItemApi.List();//UserId, CartId olan Id değerlerine göre list gelmeli
        //SESSION işlemi yapılabilir. Biz şimdilik 1 verdik.

        return Json(new { success = true, data = getCartItem });
    }

    public IActionResult CartItemList(int userId)
    {
        var getCartItem = _cartItemApi.List();
        //ViewBag.category = _categoryApi.List();//Component

        return View(getCartItem);
    }

    // public IActionResult AddCart(int id)
    public JsonResult AddCart(int id)//giriş(Açık)
    {
        CreateCartRequestModel model = new CreateCartRequestModel();
        model.ProductId = id;
        model.UserId = 1;//session işlemi yapılabilir. Biz şimdilik 1 verdik.
        var result = _cartApi.AddCart(model);
        //sepet için cookie işlemi, session işlemi  yapılabilir. Biz DB ye ekleme işlemi yaptık.
        if (result)
        {
           //giriş yapan kullanıcı için sepete eklediği bütün ürünleri getir
            var getProduct = _productApi.GetById(id);//ürün sayısı db de CartItem da bir prop olarak tutulacak

            return Json(new { success = true, data = getProduct });//bitiş-Kapatılacak
        }

        return Json(new { success = false });

    }

    public IActionResult PaymentSuccess()
    {
        //Ödeme başarılı sayfası bootsnippet ya da css ile kendin kodlayarak yap
        return View();
    }
}
