using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Cart;

public class CreateCartRequestModel:BaseCreateModel
{
    public int UserId { get; set; }
}
