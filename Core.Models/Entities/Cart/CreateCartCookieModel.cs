using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Cart;

public class CreateCartCookieModel: BaseCreateModel
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string Picture { get; set; }=string.Empty;
}
