namespace Core.Models.Entities.CartItem;

public class CartItemResponseModel
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }
    public string PictureUrl { get; set; }
    public string ProductName { get; set; } = string.Empty;
}
