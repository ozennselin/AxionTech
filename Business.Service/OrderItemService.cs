using Business.Service.Interfaces;
using Core.Models.Entities.OrderItem;

namespace Business.Service;

public class OrderItemService : IOrderItemService
{
    public void Create(CreateOrderItemRequestModel request)
    {
        throw new NotImplementedException();
    }

    public void Delete(DeleteOrderItemRequestModel request)
    {
        throw new NotImplementedException();
    }

    public List<OrderItemResponseModel> GetByOrderId(int orderId)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateOrderItemRequestModel request)
    {
        throw new NotImplementedException();
    }
}
