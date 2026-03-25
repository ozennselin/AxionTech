using Core.Models.Entities.CartItem;

namespace Core.Models.Entities.Cart;

public class CartResponseModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<CartItemResponseModel> Items { get; set; } = new();
}
