namespace Business.Service.Interfaces;

 public interface IProductService
{
    void Create(CreateProductRequestModel request);
    void Update(UpdateProductRequestModel request);
    void Delete(DeleteProductRequestModel request);
    List<ProductResponseModel> List();
}
