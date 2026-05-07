using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Components;

public class ProductPriceViewComponent : ViewComponent
{
    public ProductPriceViewComponent()
    {

    }

    public IViewComponentResult Invoke()
    {
        return View();
    }

}
