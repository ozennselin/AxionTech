using AxionTech.WEB.GetApi;
using Core.Models.Entities.Cart;
using Core.Models.Entities.Product;
using Data.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            var listCookie= CookieProductList();
            listCookie.Add(getProduct);
            AddToCartWithCookie(listCookie);

            #endregion

            return Json(new { success = true, data = getProduct });
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

    /// <summary>
    /// Cookie oluşturma işlemi
    /// </summary>
    /// <param name="cartCookieItems"></param>
    public void AddToCartWithCookie(List<ProductResponseModel> cartCookieItems)
    {
        
        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(7),//cookie nin geçerlilik süresi
            HttpOnly = true,//sadece sunucu tarafından erişilebilir, client tarafında js ile erişilemez
            IsEssential = true,//kullanıcı onayı gerektirmez, zorunlu cookie
                               //Secure=true,            
        };

        //Response.Cookies.Append("guestCart", JsonSerializer.Serialize(cartItems), cookieOptions);//
        var jsonStirng = JsonSerializer.Serialize(cartCookieItems);//C# formatında olan ürünleri json formatına dönüştürecek
        _httpContextAccessor.HttpContext.Response.Cookies.Append("guestCart", jsonStirng, cookieOptions);

    }

    /// <summary>
    /// Cooki de olan json formatındaki ürünleri c# formatına dönüştürüp List olarak getirir
    /// </summary>
    /// <returns></returns>
    public List<ProductResponseModel> CookieProductList()
    {
        var cookieList = _httpContextAccessor.HttpContext.Request.Cookies["guestCart"];
        if (cookieList!=null)
        {
        return  JsonSerializer.Deserialize<List<ProductResponseModel>>(cookieList);//json formatında olan Cookiedeki ürünleri c# formatına getirecek
        }
            return new List<ProductResponseModel>();
    }

    public IActionResult PaymentSuccess()
    {
        //Ödeme başarılı sayfası bootsnippet ya da css ile kendin kodlayarak yap
        return View();
    }
}
