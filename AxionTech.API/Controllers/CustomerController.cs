using Business.Service.Interfaces;
using Core.Models.Entities.Customer;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : BaseAPIController
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateCustomerRequestModel request)
    {
        _customerService.Create(request);
        return ResultAPI(request);
    }

    [HttpGet("List")]
    public IActionResult List()
    {
        var list = _customerService.List();
        return ResultAPI(list);
    }
}
