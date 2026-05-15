using AxionTech.WEB.GetApi;
using Core.Models.Entities.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
public class DashboardController : Controller
{
    private readonly ProductApi _productApi;
    private readonly UserApi _userApi;
    private readonly OrderApi _orderApi;
    private readonly CartApi _cartApi;

    public DashboardController(ProductApi productApi, UserApi userApi, OrderApi orderApi, CartApi cartApi)
    {
        _productApi = productApi;
        _userApi = userApi;
        _orderApi = orderApi;
        _cartApi = cartApi;
    }

    public IActionResult Index()
    {
        var orderList = _orderApi.List();

        var model = new DashboardResponseModel
        {
            ProductCount = _productApi.List().Count,
            UserCount = _userApi.List().Count,
            OrderCount = orderList.Count,
            CartCount = _cartApi.List().Count,

            MonthlySales = new List<int>{
             orderList.Count(x => x.OrderDate.Month == 1),
             orderList.Count(x => x.OrderDate.Month == 2),
             orderList.Count(x => x.OrderDate.Month == 3),
             orderList.Count(x => x.OrderDate.Month == 4),
             orderList.Count(x => x.OrderDate.Month == 5),
             orderList.Count(x => x.OrderDate.Month == 6)
             }
        };

        return View(model);
    }
}