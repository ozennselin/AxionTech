using Core.Models.Entities.ProductDocument;

namespace Business.Service.Interfaces;

public interface IProductDocumentService
{
    void Create(CreateProductDocumentRequestModel request);
    void Update(UpdateProductDocumentRequestModel request);
    void Delete(DeleteProductDocumentRequestModel request);
    List<ProductDocumentResponseModel> GetByProductId(int productId);
}
