using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

public class CartController : BaseAPIController
{
    public IActionResult Index()
    {
        return Ok();
    }
}
