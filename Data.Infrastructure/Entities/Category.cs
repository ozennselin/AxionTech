using Data.Infrastructure.Abstraction;

namespace Data.Infrastructure.Entities;

public class Category:BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Product> Product { get; set; } = null;//bu yapı product tablası 1-sonsuz bağlantıyı gercekletırmek ıcın zorunludur
}
