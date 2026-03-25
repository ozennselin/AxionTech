using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class OrderAPController:Controller
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
}
