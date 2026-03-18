using Data.Infrastructure.Abstraction;

namespace Data.Infrastructure.Entities;

public class Order:BaseEntity
{
    public string OrderNo { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int UserId { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
