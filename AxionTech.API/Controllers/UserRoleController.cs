using Business.Service.Interfaces;
using Core.Models.Entities.UserRole;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRoleController : BaseAPIController
{
    private readonly IUserRoleService _userRoleService;

    public UserRoleController(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    [HttpPost("Create")]
    public IActionResult Create(CreateUserRoleRequestModel request)
    {
        _userRoleService.Create(request);
        return ResultAPI(Core.Enums.ResponseMessageEnum.Success);
    }

    [HttpPost("Update")]
    public IActionResult Update(UpdateUserRoleRequestModel request)
    {
        _userRoleService.Update(request);
        return ResultAPI(Core.Enums.ResponseMessageEnum.Success);
    }

    [HttpPost("Delete")]
    public IActionResult Delete(DeleteUserRoleRequestModel request)
    {
        _userRoleService.Delete(request);
        return ResultAPI(Core.Enums.ResponseMessageEnum.Success);
    }

    [HttpGet("GetByUserId")]
    public IActionResult GetByUserId(int userId)
    {
        var result = _userRoleService.GetByUserId(userId);
        return ResultAPI(result);
    }

    [HttpGet("GetByRoleId")]
    public IActionResult GetByRoleId(int roleId)
    {
        var result = _userRoleService.GetByRoleId(roleId);
        return ResultAPI(result);
    }
}