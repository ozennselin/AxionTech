using Core.Models.Entities.ProductDocument;
using Core.Models.Entities.ProductPicture;
using Core.Models.Entities.ProductPrice;

namespace Core.Models.Entities.Product;

public class ProductDetailResponseModel
{
    public ProductResponseModel ProductDetail { get; set; }
    public List<ProductPictureResponseModel> ProductPicture { get; set; } 
    public List<ProductDocumentResponseModel> ProductDocument { get; set; }
    public ProductPriceResponseModel ProductPrice { get; set; }
}
