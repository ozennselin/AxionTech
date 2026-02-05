using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseAPIController// ControllerBase
    {

        public ProductController()
        {
            string islem = "";
        }

        // [HttpPost]
        // public IActionResult ProductInsert([FromBody] ProductInsertRequest request)
        //// public IActionResult ProductInsert([FromBody] string name,double price)??//Ayarlar mevcut
        // {
        //     return Ok("Adı "+request.Name+" olan ürünün fiyatı:"+request.Price);
        // }

        [HttpPost]
        public IActionResult ProductInsert([FromBody]ProductInsertRequest request)
        {
            return Ok("Postman işlemi:" + request);
            /*
             Başarılı=> *******************************
            1.Durum)2xx=> Başarılı Mesajı***
            2.Durum) 2xx=> Başarılı ama hangi ürün eklendi ver bana=> Id,il, ilçe
            1=> Ürün Ekle=> Ürün başarılı bir şekilde eklendi
            2=>ürün adı Monitör, fiyatı 15.000 , stok 8 (Product) olan ürününüz için aşağıdaki indirimlerden birini uygulayın
            
            Başarısız=>*************************
            1.Durum) 4xx=> Başarısız meajı
            2.Durum)4xx=> Başarısız, nedeni? Stok ondalık olmaz, Name alanı zorunlu, ....

            */
        }
    }
}
