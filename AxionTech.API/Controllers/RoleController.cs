using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Role;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : BaseAPIController
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("List")]
    public IActionResult List()
    {
        var list = _roleService.List();
        return ResultAPI(list);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var role = _roleService.GetById(id);

        if (role == null)
        {
            return NotFound("Rol bulunamadı");
        }

        return ResultAPI(role);
    }

    [HttpPost("Create")]
    public IActionResult Create(CreateRoleRequestModel request)
    {
        var result = _roleService.Create(request);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
        {
            return ResultAPI(result);
        }

        return BadRequest(new { Message = "Rol oluşturulamadı", ErrorCode = result });
    }

    [HttpPost("Update")]
    public IActionResult Update(UpdateRoleRequestModel request)
    {
        var result = _roleService.Update(request);
        return ResultAPI(result);
    }

    [HttpPost("Delete")]
    public IActionResult Delete(DeleteRoleRequestModel request)
    {
        var result = _roleService.Delete(request);
        return ResultAPI(result);
    }
}