using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Menu;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuController : BaseAPIController
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody]CreateMenuRequestModel request)
    {
        var result = _menuService.Create(request);
        if (result.Item1 == Core.Enums.ResponseMessageEnum.Success)
        {
            return ResultAPI(result.Item2);
        }
        return BadRequest(new { Message = ResponseMessageEnum.ErrorWithData, ErrorCode = result.Item1 });
    }

     
}
