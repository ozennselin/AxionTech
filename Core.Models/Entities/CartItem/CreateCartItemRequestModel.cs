using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.CartItem;

public class CreateCartItemRequestModel:BaseCreateModel
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
