using Core.Models.Entities.Order;

namespace Business.Service.Interfaces;

public interface IOrderService
{
    void Create(CreateOrderRequestModel request);
    void Update(UpdateOrderRequestModel request);
    void Delete(DeleteOrderRequestModel request);
    List<OrderResponseModel> List();
}
