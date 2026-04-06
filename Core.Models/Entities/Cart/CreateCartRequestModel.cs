using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Cart;

public class CreateCartRequestModel:BaseCreateModel
{
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public decimal UnitPrice { get; set; }
}
