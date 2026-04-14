using Data.Infrastructure.Abstraction;

namespace Data.Infrastructure.Entities;

public class Category:BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ParentId { get; set; }//parentId ile üst/alt kategori mantığını oluşturacağız

    public ICollection<Product> Products{ get; set; } = new List<Product>();//bu yapı product tablası 1-sonsuz bağlantıyı gercekletırmek ıcın zorunludur
}
