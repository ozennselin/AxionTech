using Business.Service;
using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.MenuRole;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuRoleController : BaseAPIController
{
    private readonly IMenuRoleService _menuRoleService;

    public MenuRoleController(IMenuRoleService menuRoleService)
    {
        _menuRoleService = menuRoleService;
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] List<CreateMenuRoleRequestModel> request)
    {
        var result = _menuRoleService.Create(request);

        if (result == ResponseMessageEnum.Success)
        {
            return ResultAPI(result);
        }

        return BadRequest(new
        {
            Message = ResponseMessageEnum.ErrorWithData,
            ErrorCode = result
        });
    }

    [HttpGet("List")]
    public IActionResult List()
    {
        var list = _menuRoleService.List();

        return ResultAPI(list);
    }
}