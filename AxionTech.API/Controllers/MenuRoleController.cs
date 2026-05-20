using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

public class MenuRoleController : Controller
{
    [HttpGet("List")]
    public IActionResult List()
    {
        return Ok();
    }
}
