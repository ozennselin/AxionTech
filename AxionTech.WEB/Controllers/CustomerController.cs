using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Controllers;

public class CustomerController : Controller
{
     private readonly CustomerApi _customerApi;

    public CustomerController(CustomerApi customerApi)
    {
        _customerApi = customerApi;
    }

    public IActionResult List()
    {
        var list = _customerApi.List();
        return View(list);
    }
}
