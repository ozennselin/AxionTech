using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Product;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseAPIController// ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // [HttpPost]
        // public IActionResult ProductInsert([FromBody] ProductInsertRequest request)
        //// public IActionResult ProductInsert([FromBody] string name,double price)??//Ayarlar mevcut
        // {
        //     return Ok("Adı "+request.Name+" olan ürünün fiyatı:"+request.Price);
        // }

        [HttpPost]
        public IActionResult ProductInsert([FromBody] ProductInsertRequestModel request)
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

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _productService.List();
            return ResultAPI(list);
        }

        [HttpPut("Detail/{id}")]
        public IActionResult Detail(int id)
        {
            var product = _productService.GetById(id);
            return ResultAPI(product);

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            return ResultAPI(product);
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateProductRequestModel request)
        {
            var result = _productService.Update(request);
            return ResultAPI(result);
        }


        [HttpPut("Delete")]
        public IActionResult Delete(DeleteProductRequestModel request)
        {
            var result = _productService.Delete(request);
            return ResultAPI(result);
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateProductRequestModel request)
        {
            var result = _productService.Create(request);

            if (result == ResponseMessageEnum.Success)
            {
                return ResultAPI(result);
            }
            return BadRequest(new { Message = ResponseMessageEnum.Exist, ErrorCode = result });
        }

    }
}
