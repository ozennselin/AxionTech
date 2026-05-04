using AxionTech.WEB.GetApi;
using Core.Enums;
using Core.Models.Entities.ProductPrice;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]

public class ProductPriceAPController : Controller
{
    private readonly ProductPriceApi _productPriceApi;

    public ProductPriceAPController(ProductPriceApi productPriceApi)
    {
        _productPriceApi = productPriceApi;
    }

    public IActionResult List()
    {
        var list = _productPriceApi.List();
        return View(list);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateProductPriceRequestModel request)
    {
        var result = _productPriceApi.Create(request);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
            return RedirectToAction("List");

        ViewBag.Error = result.ToString();
        return View(request);
    }

    public IActionResult Update(int productId)
    {
        var price = _productPriceApi.GetPriceByProductId(productId);
        return View(price);
    }

    [HttpPost]
    public IActionResult Update(UpdateProductPriceRequestModel request)
    {
        var result = _productPriceApi.Update(request);

        if (result == ResponseMessageEnum.Success || result == ResponseMessageEnum.UpdateSuccess)
            return RedirectToAction("List");

        ViewBag.Error = result.ToString();
        var price = _productPriceApi.GetPriceByProductId(request.ProductId);
        return View(price);
    }

    public IActionResult Delete(int productId)
    {
        var price = _productPriceApi.GetPriceByProductId(productId);
        return View(price);
    }

    [HttpPost]
    public IActionResult Delete(DeleteProductPriceRequestModel request)
    {
        var result = _productPriceApi.Delete(request);

        if (result == ResponseMessageEnum.Success)
            return RedirectToAction("List");

        return View();
    }
}
