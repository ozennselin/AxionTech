using Core.Models.Entities.Product;
using Core.Models.Entities.ProductDocument;

namespace Business.Service.Interfaces;

public interface IProductDocumentService
{
    void Create(CreateProductRequestModel request);
    void Update(UpdateProductRequestModel request);
    void Delete(DeleteProductRequestModel request);
    List<ProductDocumentResponseModel> GetByProductId(int productId);
}
