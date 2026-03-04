using Core.Models.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Entities.ProductPrice;

public class CreateProductPriceRequestModel:BaseCreateModel
{
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}
