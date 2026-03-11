using Data.Infrastructure.Abstraction;

namespace Data.Infrastructure.Entities;

public class ProductPicture:BaseEntity
{
    public int ProductId { get; set; }
    public string Url { get; set; } = string.Empty;
    public bool IsMain { get; set; } = false;
    public int DisplayOrder { get; set; } = 0;

    public Product Product { get; set; } = null!;
}
