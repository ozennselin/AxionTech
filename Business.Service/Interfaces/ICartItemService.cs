using Core.Models.Entities.CartItem;

namespace Business.Service.Interfaces;

public interface ICartItemService
{
    void Create(CreateCartItemRequestModel request);
    void Update(UpdateCartItemRequestModel request);
    void Delete(DeleteCartItemRequestModel request);
    List<CartItemResponseModel> GetByCartId(int cartId);
}
