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
        if (result.Item1 ==ResponseMessageEnum.Success)
        {
            return ResultAPI(result.Item1);
        }
        return BadRequest(new { Message = ResponseMessageEnum.ErrorWithData, ErrorCode = result.Item1 });
    }
    
    [HttpGet("List")]
    public IActionResult List()
    {
        var list = _menuService.List();

        return ResultAPI(list);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var menu = _menuService.GetById(id);

        return ResultAPI(menu);
    }

    [HttpPost("Update")]
    public IActionResult Update([FromBody] UpdateMenuRequestModel request)
    {
        var result = _menuService.Update(request);

        if (result == ResponseMessageEnum.UpdateSuccess)
        {
            return ResultAPI(result);
        }

        return BadRequest(new
        {
            Message = ResponseMessageEnum.ErrorWithData,
            ErrorCode = result
        });
    }
   
    [HttpPost("Delete")]
    public IActionResult Delete([FromBody] DeleteMenuRequestModel request)
    {
        var result = _menuService.Delete(request);

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
}
