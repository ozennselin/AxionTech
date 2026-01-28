namespace Core.Models.Entities.OrderItem;

public class OrderItemResponseModel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }
}
