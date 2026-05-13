using AxionTech.WEB.GetApi;
using Core.Enums;
using Core.Models.Entities.Customer;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
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
    public IActionResult Detail(int id)
    {
        var customer = _customerApi.GetById(id);
        return View(customer);
    }
    public IActionResult Update(int id)
    {
        var customer = _customerApi.GetById(id);
        return View(customer);
    }

    [HttpPost]
    public IActionResult Update(UpdateCustomerRequestModel request)
    {
        var result = _customerApi.Update(request);

        if (result == "SUCCESS")
        {
            return RedirectToAction("List");
        }

        ViewBag.Error = result;
        var customer = _customerApi.GetById(request.Id);
        return View(customer);
    }
    public IActionResult Delete(int id)
    {
        var customer = _customerApi.GetById(id);
        return View(customer);
    }

    [HttpPost]
    public IActionResult Delete(DeleteCustomerRequestModel request)
    {
        _customerApi.Delete(request);
        return RedirectToAction("List");
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateCustomerRequestModel request)
    {
        var result = _customerApi.Create(request);

        if (result)
        {
            return RedirectToAction("List");
        }

        request.Message=ResponseMessageEnum.Error.ToString();
        return View(request);
    }


}
