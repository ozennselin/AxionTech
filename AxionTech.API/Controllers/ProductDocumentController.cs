using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AxionTech.API.Controllers;

public class ProductDocumentController : BaseAPIController
{
    public IActionResult Index()
    {
        return Ok();
    }
}
