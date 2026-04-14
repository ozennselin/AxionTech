using Core.Enums;
using Core.Models.Entities.Order;

namespace Business.Service.Interfaces;

public interface IOrderService
{
    List<OrderResponseModel> List();

    OrderResponseModel? GetById(int id);

    ResponseMessageEnum UpdateStatus(int orderId, string status);
}