using Business.Service.Interfaces;
using Core.Models.Entities.Category;
using Data.Access.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
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
            return Ok();
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            return Ok();
        }
    }
}
