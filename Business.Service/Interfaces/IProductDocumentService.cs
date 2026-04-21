using Core.Enums;
using Core.Models.Entities.ProductDocument;

namespace Business.Service.Interfaces;

public interface IProductDocumentService
{
    ResponseMessageEnum Create(CreateProductDocumentRequestModel request);
    void Update(UpdateProductDocumentRequestModel request);
    ResponseMessageEnum Delete(DeleteProductDocumentRequestModel request);
    List<ProductDocumentResponseModel> GetByProductId(int productId);
}
