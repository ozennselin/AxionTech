using Business.Service.Interfaces;
using Core.Models.Entities.Order;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

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
        var createOrder = new Order
        {
            OrderNo = request.OrderNo,
            OrderDate = request.OrderDate,
            TotalAmount = request.TotalAmount,
            Status = request.Status,
            Address = request.Address,
            UserId = request.UserId
        };

        _orderRepository.Add(createOrder);
    }

    public void Delete(DeleteOrderRequestModel request)
    {
        var ordertodelete = _orderRepository.GetById(request.Id);
        if (ordertodelete == null)
        {
            _orderRepository.Delete(ordertodelete);
        }
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
        var ordertoUpdate = _orderRepository.GetById(request.Id);
      if (ordertoUpdate == null)
        {
            ordertoUpdate.OrderNo = request.OrderNo;
            ordertoUpdate.OrderDate = request.OrderDate;
            ordertoUpdate.TotalAmount = request.TotalAmount;
            ordertoUpdate.Status = request.Status;
            ordertoUpdate.Address = request.Address;
            ordertoUpdate.UserId = request.UserId;
            _orderRepository.Update(ordertoUpdate);
        }
    }
}
