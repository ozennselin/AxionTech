using AxionTech.WEB.GetApi;
using Core.Models.Entities.Cart;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class CartController : BaseController
{
    private readonly CartApi _cartApi;
    private readonly CartItemApi _cartItemApi;
    private readonly ProductApi _productApi;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartController(CartApi cartApi, HttpClient httpClient, ProductApi productApi, CartItemApi cartItemApi, IHttpContextAccessor httpContextAccessor) : base(httpClient)
    {
        _cartApi = cartApi;
        _productApi = productApi;
        _cartItemApi = cartItemApi;
        _httpContextAccessor = httpContextAccessor;
    }

    public IActionResult List()
    {
        var userId = GetSessionUserId();
        var getCartItem = _cartItemApi.List(userId);//UserId, CartId olan Id değerlerine göre list gelmeli
        //SESSION işlemi yapılabilir. Biz şimdilik 1 verdik.

        return Json(new { success = true, data = getCartItem });
    }

    public IActionResult CartItemList()
    {
        var sessionUserId = GetSessionUserId();

        var getCartItem = _cartItemApi.List(sessionUserId);
        //ViewBag.category = _categoryApi.List();//Component

        return View(getCartItem);
    }

    // public IActionResult AddCart(int id)
    public JsonResult AddCart(int id)//giriş(Açık)
    {
        if (GetSessionUserId() == 0)//cookie ye ekle=> Kullanıcı giriş yapmamış ise cookie işlemi yapılabilir. 
        {
            var getProduct = _productApi.GetById(id);
            //yukardaki ürün ve ürüne ait Price, Picture bilgileri cookie ye eklenebilir.

            #region Cookie git

            //her eklenen ürün cookie gönderilecek
            // AddToCartWithCookie(list);
            //ilk önce Cookie de ürün var mı sorgusu yapacağım, eğer ürün varsa o ürünleri getirecek list olarak tutacağım ve yeni ürünü liste ekleyip Cookie ye tekrar yeni ürünle beraber oluşturmak üzere AddToCartWithCookie göndereceğim, ürün cookide yoksa  aşağıdaki AddToCartWithCookie methoduna ilk ürünü eklemek için göndereceğim
            var listCookie = CookieProductList();

            var resultQuantity = listCookie.Where(k => k.ProductId == getProduct.Id).FirstOrDefault();


            if (resultQuantity != null)
            {
                resultQuantity.Quantity += 1;
            }
            else
            {
                CreateCartCookieModel cartCookieItem = new CreateCartCookieModel();
                cartCookieItem.ProductId = getProduct.Id;
                cartCookieItem.UnitPrice = getProduct.Price;
                cartCookieItem.Picture = getProduct.Picture;
                cartCookieItem.Quantity = 1;
                listCookie.Add(cartCookieItem);

            }

            AddToCartWithCookie(listCookie);

            #endregion

           // return Json(new { success = true, data = getProduct });
            return Json(new { success = true, data = listCookie });
        }
        else
        {
            CreateCartRequestModel model = new CreateCartRequestModel();
            model.ProductId = id;
            model.UserId = GetSessionUserId();//session işlemi yapılabilir. Biz şimdilik 1 verdik.
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
        //}
        //else
        //{
        //    //Sepete eklenen ürünler için kullanıcı giriş yapmamış ise cookie işlemi, session işlemi yapılabilir. 
        //    return Json(new { success = false, message = "Lütfen giriş yapınız." });

        //}
    }

   
    

    public IActionResult PaymentSuccess()
    {
        //Ödeme başarılı sayfası bootsnippet ya da css ile kendin kodlayarak yap
        return View();
    }
}
