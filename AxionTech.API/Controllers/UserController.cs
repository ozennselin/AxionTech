using Business.Service.Interfaces;
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
}