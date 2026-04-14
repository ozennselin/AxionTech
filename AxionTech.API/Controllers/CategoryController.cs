using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Category;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : BaseAPIController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateCategoryRequestModel request)
    {
        var result = _categoryService.Create(request);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
        {
            return ResultAPI(result);
        }

        return BadRequest(new { Message = "Category oluşturulamadı", ErrorCode = result });
    }

    [HttpGet("List")]
    public IActionResult List()
    {
        var list = _categoryService.List();
        return ResultAPI(list);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var category = _categoryService.GetById(id);

        if (category == null)
        {
            return NotFound("Kategori bulunamadı");
        }

        return ResultAPI(category);
    }

    [HttpPost("Update")]
    public IActionResult Update([FromBody] UpdateCategoryRequestModel request)
    {
        var result = _categoryService.Update(request);
        return ResultAPI(result);
    }

    [HttpPost("Delete")]
    public IActionResult Delete([FromBody] DeleteCategoryRequestModel request)
    {
        var result = _categoryService.Delete(request);
        return ResultAPI(result);
    }
}