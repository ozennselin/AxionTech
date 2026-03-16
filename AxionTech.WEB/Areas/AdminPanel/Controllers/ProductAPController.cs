using AxionTech.WEB.GetApi;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Areas.AdminPanel.Controllers;

public class ProductAPController : Controller
{
    private readonly ProductApi _productApi;

    public ProductAPController(ProductApi productApi)
    {
        _productApi = productApi;
    }

    public IActionResult List()
    {
        var list=_productApi.List();
        return View(list);
    }
}

