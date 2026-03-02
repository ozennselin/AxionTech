using Business.Service;
using Business.Service.Interfaces;
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
}
