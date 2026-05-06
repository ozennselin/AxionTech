using AxionTech.WEB.GetApi;
using Core.Models.Entities.Category;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Components;

[ViewComponent(Name = "Category")]
public class CategoryViewComponent : ViewComponent
{
    private readonly CategoryApi _categoryApi;

    public CategoryViewComponent(CategoryApi categoryApi)
    {
        _categoryApi = categoryApi;
    }


    public async Task<IViewComponentResult> InvokeAsync()
    {
        var list = await _categoryApi.ListAsync();
        return View(list);
    }

}
