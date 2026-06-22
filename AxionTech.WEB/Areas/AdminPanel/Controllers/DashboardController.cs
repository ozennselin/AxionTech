using AxionTech.WEB.GetApi;
using Core.Models.Entities.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
public class DashboardController : BaseController
{
    private readonly ProductApi _productApi;
    private readonly UserApi _userApi;
    private readonly OrderApi _orderApi;
    private readonly CartApi _cartApi;
    private readonly MenuRoleApi _menuRoleApi;



    public DashboardController(ProductApi productApi, OrderApi orderApi, CartApi cartApi, MenuRoleApi menuRoleApi, UserApi userApi = null) : base(menuRoleApi, userApi)
    {
        _productApi = productApi;
        _userApi = userApi;
        _orderApi = orderApi;
        _cartApi = cartApi;
        _menuRoleApi = menuRoleApi;
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

            MonthlySales = Enumerable.Range(1, 12).Select(month => orderList.Count(x => x.OrderDate.Month == month)).ToList(),

            LastOrders = orderList
                 .OrderByDescending(x => x.OrderDate)
                 .Take(5)
                 .ToList()
        };

        return View(model);
    }
}