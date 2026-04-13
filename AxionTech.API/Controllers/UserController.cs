using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseAPIController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("List")]
    public IActionResult List()
    {
        var list = _userService.List();
        return ResultAPI(list);
    }

    [HttpPost("Login")]
    public IActionResult Login(UserLoginModel request)
    {
        var result = _userService.Login(request);
        return Ok(result);
    }

    [HttpPost("Create")]
    public IActionResult Create(CreateUserRequestModel request)
    {
        var result = _userService.Create(request);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
        {
            return ResultAPI(result);
        }

        return BadRequest(new { Message = "Kullanıcı oluşturulamadı", ErrorCode = result });
    }

    [HttpPost("Update")]
    public IActionResult Update(UpdateUserRequestModel request)
    {
        var result = _userService.Update(request);
        return ResultAPI(result);
    }

    [HttpPost("Delete")]
    public IActionResult Delete(DeleteUserRequestModel request)
    {
        var result = _userService.Delete(request);
        return ResultAPI(result);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);

        if (user == null)
        {
            return NotFound("Kullanıcı bulunamadı");
        }

        return ResultAPI(user);
    }
}