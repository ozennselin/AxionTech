using Business.Service.Interfaces;
using Core.Models.Entities.CartItem;

namespace Business.Service;

public class CartItemService : ICartItemService
{
    public void Create(CreateCartItemRequestModel request)
    {
        //ders için sepet
        throw new NotImplementedException();
    }

    public void Delete(DeleteCartItemRequestModel request)
    {
        throw new NotImplementedException();
    }

    public List<CartItemResponseModel> GetByCartId(int cartId)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateCartItemRequestModel request)
    {
        throw new NotImplementedException();
    }
}
