using Data.Infrastructure.Abstraction;

namespace Data.Infrastructure.Entities;

public class ProductDocument:BaseEntity
{
    public int ProductId { get; set; }

    public string Url { get; set; } = string.Empty;     
    public string FileName { get; set; } = string.Empty; 
    public string FileType { get; set; } = string.Empty; 

    public Product Product { get; set; } = null!;
}
