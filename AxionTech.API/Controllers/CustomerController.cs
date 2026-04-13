using Business.Service.Interfaces;
using Core.Enums;
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
        var result = _customerService.Create(request);

        if (result == ResponseMessageEnum.Success)
        {
            return ResultAPI(result);
        }

        return BadRequest(new { Message = "Customer oluşturulamadı", ErrorCode = result });
    }

    [HttpGet("List")]
    public IActionResult List()
    {
        var list = _customerService.List();
        return ResultAPI(list);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var customer = _customerService.GetById(id);

        if (customer == null)
            return NotFound("Kayıt bulunamadı");

        return ResultAPI(customer);
    }
    [HttpPost("Update")]
    public IActionResult Update(UpdateCustomerRequestModel request)
    {
        _customerService.Update(request);
        return ResultAPI(request);
    }

    [HttpPost("Delete")]
    public IActionResult Delete(DeleteCustomerRequestModel request)
    {
        _customerService.Delete(request);
        return ResultAPI(request);
    }

}
