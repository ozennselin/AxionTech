using AxionTech.WEB.GetApi;
using Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class OrderAPController : Controller
{
    private readonly OrderApi _orderApi;

    public OrderAPController(OrderApi orderApi)
    {
        _orderApi = orderApi;
    }

    public IActionResult List()
    {
        var list = _orderApi.List();
        return View(list);
    }

    public IActionResult Detail(int id)
    {
        var order = _orderApi.GetById(id);
        return View(order);
    }

    [HttpPost]
    public IActionResult UpdateStatus(int orderId, string status)
    {
        var result = _orderApi.UpdateStatus(orderId, status);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
            return RedirectToAction("List");

        return RedirectToAction("Detail", new { id = orderId });
    }
}