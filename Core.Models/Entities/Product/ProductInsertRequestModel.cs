using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Entities.Product;

public class ProductInsertRequestModel
{  
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
}

