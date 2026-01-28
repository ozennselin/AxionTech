using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Cart;

public class UpdateCartRequestModel:BaseUpdateModel
{
    public int UserId { get; set; }
}
