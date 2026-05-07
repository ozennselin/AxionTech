using Microsoft.AspNetCore.Mvc;

namespace AxionTech.WEB.Components;

public class CartViewComponent : ViewComponent
{

    public IViewComponentResult Invoke()
    {
        //varsa GetUser DB den sepet bilgilerini getir, yoksa cookie den getir
        return View();
    }
}
