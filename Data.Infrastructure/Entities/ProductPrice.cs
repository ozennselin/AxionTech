using Data.Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure.Entities;

public class ProductPrice:BaseEntity
{
    public decimal Price { get; set; }
    public int ProductId { get; set; }
    public string Description { get; set; }=string.Empty;
    public bool IsActive { get; set; }
    public Product Product { get; set; } 
}
