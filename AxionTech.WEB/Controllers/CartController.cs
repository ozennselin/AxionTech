using AxionTech.WEB.GetApi;
using Core.Models.Entities.Cart;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Core.Models.Entities.CartItem;


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
    private int GetSessionUserId()
    {
        var userId = HttpContext.Session.GetString("UserId");

        if (string.IsNullOrEmpty(userId))
        {
            return 0;
        }

        return Convert.ToInt32(userId);
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
#warning "Bu method giriş yapmamış kullanıcılar için çalışmaz, cookie işlemi yapılabilir." DEVAM EDİLECEK
        if (GetSessionUserId() == 0)//cookie ye ekle
        {
            var getProduct = _productApi.GetById(id);
            //yukardaki ürün ve ürüne ait Price, Picture bilgileri cookie ye eklenebilir.
            AddCartWithCookie(id);
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


    public JsonResult AddCartWithCookie(int id)
    {
        var getProduct = _productApi.GetById(id);
        if (getProduct != null)
        {
            return Json(new { success = false });
        }

        var createCookie = Request.Cookies["guestCart"];//Cookie için isim verdik, bu isim proje içinde ayı session gibi unique (benzersiz) olmalıdır
        //Request=> istek

        List<CreateCartCookieModel> cartItems;

        if (createCookie != null)
        {
            cartItems = JsonSerializer.Deserialize<List<CreateCartCookieModel>>(createCookie);
        }
        else
        {
            cartItems = new List<CreateCartCookieModel>();
        }

        //Sepetin varsa miktar artır, yoksa yeni ürün ekle
        var existingCartItem = cartItems.FirstOrDefault(c => c.ProductId == id);
        if (existingCartItem == null)
        {
            //yeni ekle
            cartItems.Add(new CreateCartCookieModel
            {
                ProductId = id,
                Quantity = 1,
                UnitPrice = getProduct.Price,
                CreateDate = DateTime.Now
            });
        }
        else
        {
            //miktar artır
            existingCartItem.Quantity += 1;
        }

        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(7),//cookie nin geçerlilik süresi
            HttpOnly = true,//sadece sunucu tarafından erişilebilir, client tarafında js ile erişilemez
            IsEssential = true//kullanıcı onayı gerektirmez, zorunlu cookie
        };
        Response.Cookies.Append("guestCart", JsonSerializer.Serialize(cartItems), cookieOptions);//

        return Json(new { success = true, data = cartItems });
    }

    public IActionResult PaymentSuccess()
    {
        //Ödeme başarılı sayfası bootsnippet ya da css ile kendin kodlayarak yap
        return View();
    }
}
