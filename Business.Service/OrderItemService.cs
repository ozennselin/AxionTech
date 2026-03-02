using Business.Service.Interfaces;
using Core.Models.Entities.OrderItem;
using Data.Access.Repositories.Interfaces;

namespace Business.Service;

public class OrderItemService : IOrderItemService
{

    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IUserRepository _userRepository;
    private IOrderRepository _orderRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

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

    public void TestMethod(int Id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateOrderItemRequestModel request)
    {
        throw new NotImplementedException();
    }
}
