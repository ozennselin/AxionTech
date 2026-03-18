using Business.Service.Interfaces;
using Core.Models.Entities.OrderItem;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class OrderItemService : IOrderItemService
{

    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository, IUserRepository userRepository, IOrderRepository orderRepository)
    {
        _orderItemRepository = orderItemRepository;
       _userRepository = userRepository;
        _orderRepository = orderRepository;
    }

    public void Create(CreateOrderItemRequestModel request)
    {
        var createOrderItem = new OrderItem
        {
            OrderId = request.OrderId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            UnitPrice = request.UnitPrice,
            LineTotal = request.LineTotal
        };
        _orderItemRepository.Add(createOrderItem);
        
    }

    public void Delete(DeleteOrderItemRequestModel request)
    {
        var orderItemToDelete = _orderItemRepository.GetById(request.Id);
        if (orderItemToDelete == null)
        {
            return;
        }
        _orderItemRepository.Delete(orderItemToDelete);
    }

    public List<OrderItemResponseModel> GetByOrderId(int orderId)
    {
        var orderItems = _orderItemRepository.GetAll().Where(x => x.OrderId == orderId).ToList();
        return orderItems.Select(x => new OrderItemResponseModel
        {
            Id = x.Id,
            OrderId = x.OrderId,
            ProductId = x.ProductId,
            Quantity = x.Quantity,
            UnitPrice = x.UnitPrice,
            LineTotal = x.LineTotal
        }).ToList();
    }

    public void TestMethod(int Id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateOrderItemRequestModel request)
    {
       var orderItemToUpdate = _orderItemRepository.GetById(request.Id);
        if (orderItemToUpdate == null)
        {
            throw new Exception("Order item not found");
        }
     
        orderItemToUpdate.Quantity = request.Quantity;
        orderItemToUpdate.UnitPrice = request.UnitPrice;
        orderItemToUpdate.LineTotal = request.LineTotal;
        _orderItemRepository.Update(orderItemToUpdate);
        
    }
}
