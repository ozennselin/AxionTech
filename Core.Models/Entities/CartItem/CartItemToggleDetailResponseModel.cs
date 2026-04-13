using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Entities.CartItem;

public class CartItemToggleDetailResponseModel
{
    public int CartId { get; set; }
    public int ProducItd { get; set; }
    public string ProductName { get; set; }
    public string ProductPicture { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Price { get; set; }//Price = UnitPrice * Quantity
    public decimal Total { get; set; }
}
