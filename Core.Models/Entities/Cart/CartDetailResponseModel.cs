using Core.Models.Entities.CartItem;

namespace Core.Models.Entities.Cart;

public class CartDetailResponseModel
{
    public CartResponseModel CartDetail { get; set; }
    public List<CartItemResponseModel> Items { get; set; }
}