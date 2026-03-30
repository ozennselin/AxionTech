using AxionTech.WEB.GetApi;
using Core.Models.Entities.Category;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class CategoryAPController:Controller
{
    private readonly CategoryApi _categoryApi;

    public CategoryAPController(CategoryApi categoryApi)
    {
        _categoryApi = categoryApi;
    }
    public IActionResult List()
    {
        var list = _categoryApi.List();
        return View(list);
    }

}
