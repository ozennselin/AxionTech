using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.OrderItem;

public class CreateOrderItemRequestModel:BaseCreateModel
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }
}
