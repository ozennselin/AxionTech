using Business.Service.Interfaces;
using Core.Models.Entities.Order;
using Data.Access.Repositories.Interfaces;

namespace Business.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public void Create(CreateOrderRequestModel request)
    {
        throw new NotImplementedException();
    }

    public void Delete(DeleteOrderRequestModel request)
    {
        throw new NotImplementedException();
    }

    public List<OrderResponseModel> List()
    {
        var orders = _orderRepository.GetAll().ToList();

        return orders.Select(x => new OrderResponseModel
        {
          
            OrderNo = x.OrderNo,
            OrderDate = x.OrderDate,
            TotalAmount = x.TotalAmount,
            Status = x.Status,
            Address = x.Address,
            UserId = x.UserId
        }).ToList();
    }

    public void Update(UpdateOrderRequestModel request)
    {
        throw new NotImplementedException();
    }
}
