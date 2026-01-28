using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.CartItem;

public class UpdateCartItemRequestModel:BaseUpdateModel
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
