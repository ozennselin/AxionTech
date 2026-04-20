using Business.Service.Interfaces;
using Core.Dtos;
using Core.Models.Entities.ProductDocument;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace AxionTech.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductDocumentController : BaseAPIController
{
    private readonly IProductDocumentService _productDocumentService;
    public ProductDocumentController(IProductDocumentService productDocumentService)
    {
        _productDocumentService = productDocumentService;
    }
    [HttpGet("GetByProductId")]
    public IActionResult GetByProductId(int Id)
    {
        var getDocument = _productDocumentService.GetByProductId(Id);
        return ResultAPI(getDocument);
    }


}
