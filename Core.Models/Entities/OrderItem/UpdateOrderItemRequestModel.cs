using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.OrderItem;

public class UpdateOrderItemRequestModel:BaseUpdateModel
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }
}
