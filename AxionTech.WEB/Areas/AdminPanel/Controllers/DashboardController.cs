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
        var model = new DashboardResponseModel
        {
            ProductCount = _productApi.List().Count,
            UserCount = _userApi.List().Count,
            OrderCount = _orderApi.List().Count,
            CartCount = _cartApi.List().Count
        };

        return View(model);
    }
}