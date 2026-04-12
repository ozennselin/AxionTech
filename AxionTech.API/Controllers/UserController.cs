using Business.Service.Interfaces;
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
        _userService.Create(request);
        return Ok("Kullanıcı eklendi");
    }
    [HttpPost("Update")]
    public IActionResult Update(UpdateUserRequestModel request)
    {
        _userService.Update(request);
        return Ok("Kullanıcı güncellendi");
    }
    [HttpPost("Delete")]
    public IActionResult Delete(DeleteUserRequestModel request)
    {
        _userService.Delete(request);
        return Ok("Kullanıcı pasife alındı");
    }
}