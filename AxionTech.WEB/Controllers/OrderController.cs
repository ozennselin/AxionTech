using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class OrderController : Controller
{
    private readonly OrderApi _orderApi;
    private readonly CategoryApi _categoryApi;

    public OrderController(OrderApi orderApi, CategoryApi categoryApi = null)
    {
        _orderApi = orderApi;
        _categoryApi = categoryApi;
    }

    public IActionResult List()
    {
        var list = _orderApi.List();
        return View(list);
    }

    public IActionResult CheckOrder()
    {
        //ViewBag.category = _categoryApi.List();//Component yapıldı gerek kalmadı
        return View();
    }
}
