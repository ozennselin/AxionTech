using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Order;
using Core.Models.Entities.OrderItem;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public List<OrderResponseModel> List()
    {
        var orders = _orderRepository
            .GetAll()
            .ToList();

        return orders.Select(x => new OrderResponseModel
        {
            Id = x.Id,
            OrderNo = x.OrderNo,
            OrderDate = x.OrderDate,
            TotalAmount = x.TotalAmount,
            Status = x.Status,
            Address = x.Address,
            UserId = x.UserId
        }).ToList();
    }

    public OrderResponseModel? GetById(int id)
    {
        var order = _orderRepository.GetAll().Include(x => x.OrderItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);

        if (order == null)
            return null;

        return new OrderResponseModel
        {
            Id = order.Id,
            OrderNo = order.OrderNo,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount,
            Status = order.Status,
            Address = order.Address,
            UserId = order.UserId,

            Items = order.OrderItems.Select(i => new OrderItemResponseModel
            {
                ProductId = i.ProductId,
                ProductName = i.Product != null ? i.Product.Name : "",
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                LineTotal = i.LineTotal
            }).ToList()
        };
    }

    public ResponseMessageEnum UpdateStatus(int orderId, string status)
    {
        try
        {
            var order = _orderRepository.GetById(orderId);

            if (order == null)
                return ResponseMessageEnum.NotFound;

            order.Status = status;

            _orderRepository.Update(order);

            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }
}