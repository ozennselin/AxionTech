using Core.Enums;
using Core.Models.Entities.Cart;

namespace Business.Service.Interfaces;

public interface ICartService
{
    ResponseMessageEnum Create(CreateCartRequestModel request);
    ResponseMessageEnum Update(UpdateCartRequestModel request);
    ResponseMessageEnum Delete(DeleteCartRequestModel request);
    CartResponseModel GetById(int id);
    List<CartResponseModel> List();
}
