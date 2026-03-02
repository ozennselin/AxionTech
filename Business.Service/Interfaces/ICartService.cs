using Core.Models.Entities.Cart;

namespace Business.Service.Interfaces;

public interface ICartService
{
    void Create(CreateCartRequestModel request);
    void Update(UpdateCartRequestModel request);
    void Delete(DeleteCartRequestModel request);
    CartResponseModel GetByCartId(int cartId);
}
