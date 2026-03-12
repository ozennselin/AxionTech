using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

public class ProductPictureController : BaseAPIController
{
    public IActionResult Index()
    {
        return Ok();
    }
}
