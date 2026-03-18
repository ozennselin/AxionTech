using Business.Service.Interfaces;
using Core.Models.Entities.Category;
using Data.Access.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]//API'ye erişim için route a ihtiyaç vardır
[ApiController]
public class CategoryController : BaseAPIController
{
    private ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpPost("Create")]
    public IActionResult Create([FromBody]CreateCategoryRequestModel request)
    {
        _categoryService.Create(request);
        return ResultAPI(request);
    }
    [HttpGet("List")]
    public IActionResult List()
    {
        var list=_categoryService.List();
        return ResultAPI(list);
    }
    [HttpPost("Update")]
    public IActionResult Update([FromBody]UpdateCategoryRequestModel request)
    {
        _categoryService.Update(request);
        return ResultAPI(request);
    }
    [HttpPost("Delete")]
    public IActionResult Delete([FromBody]DeleteCategoryRequestModel request)
    {
        _categoryService.Delete(request);
        return ResultAPI(request);
    }
}
