using Data.Infrastructure.Abstraction;

namespace Data.Infrastructure.Entities;

public class ProductPicture:BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string OrjinalName { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public string Url { get; set; } = string.Empty;
    public bool IsMain { get; set; } = false;
    public int DisplayOrder { get; set; } 

    public Product Product { get; set; } = null!;
}
