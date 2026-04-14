using Core.Models.Entities.OrderItem;

namespace Core.Models.Entities.Order;

public class OrderResponseModel
{
    public int Id { get; set; }
    public string OrderNo { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int UserId { get; set; }
    public List<OrderItemResponseModel> Items { get; set; } = new();
}
