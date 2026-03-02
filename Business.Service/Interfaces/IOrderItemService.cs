using Core.Models.Entities.OrderItem;

namespace Business.Service.Interfaces;

public interface IOrderItemService
{
    void Create(CreateOrderItemRequestModel request);
    void Update(UpdateOrderItemRequestModel request);
    void Delete(DeleteOrderItemRequestModel request);
    List<OrderItemResponseModel> GetByOrderId(int orderId);
    void TestMethod(int Id);
}
