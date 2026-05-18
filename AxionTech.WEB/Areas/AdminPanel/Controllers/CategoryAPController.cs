using AxionTech.WEB.GetApi;
using Core.Enums;
using Core.Models.Entities.Category;
using Data.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]

public class CategoryAPController : Controller
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

    public IActionResult Detail(int id)
    {
        var category = _categoryApi.GetById(id);
        return View(category);
    }

    public IActionResult Create()
    {
        var category = _categoryApi.List();
        return View(category);
    }

    [HttpPost]
    public IActionResult Create(CreateCategoryRequestModel request)
    {
        var result = _categoryApi.Create(request);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
            return RedirectToAction("List");

        ViewBag.Error = result.ToString();
        return View(request);
    }

    public IActionResult Update(int id)
    {
        ViewBag.CategoryList = _categoryApi.List();

        var category = _categoryApi.GetById(id);

        return View(category);
    }

    [HttpPost]
    public IActionResult Update(UpdateCategoryRequestModel request)
    {
        var result = _categoryApi.Update(request);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
            return RedirectToAction("List");

        ViewBag.Error = result.ToString();
        var category = _categoryApi.GetById(request.Id);
        return View(category);
    }

    public IActionResult Delete(int id)
    {
        var category = _categoryApi.GetById(id);
        return View(category);
    }

    [HttpPost]
    public IActionResult Delete(DeleteCategoryRequestModel request)
    {
        var result = _categoryApi.Delete(request);

        if (result == ResponseMessageEnum.Success)
            return RedirectToAction("List");

        return View();
    }

    [HttpGet]
    public IActionResult GetChildCategoryWithId(int parentId)
    {
        var list = _categoryApi.List().Where(k=>k.ParentId==parentId)
            .Select(c=>new
            {
                id=c.Id,
                name=c.Name
            }).ToList();
        return Json(new { success = true, data = list });
    }   
}
