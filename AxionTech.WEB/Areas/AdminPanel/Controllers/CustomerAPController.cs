using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class CustomerAPController: Controller
{
    private readonly CustomerApi _customerApi;

    public CustomerAPController(CustomerApi customerApi)
    {
        _customerApi = customerApi;
    }
     public IActionResult List()
    {
        var list = _customerApi.List();
        return View(list);
    }
}
