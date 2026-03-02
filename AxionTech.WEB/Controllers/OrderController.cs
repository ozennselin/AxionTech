using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class OrderController : Controller
{
    private readonly OrderApi _orderApi;

    public OrderController(OrderApi orderApi)
    {
        _orderApi = orderApi;
    }

    public IActionResult List()
    {
        var list = _orderApi.List();
        return View(list);
    }
}
