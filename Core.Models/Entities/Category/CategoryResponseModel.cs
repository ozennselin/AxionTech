namespace Core.Models.Entities.Category;

public class CategoryResponseModel
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ProductCount { get; set; }//her bir category de ürün sayısı list içinde verebiliriz
    public string UserNameLastname { get; set; } = string.Empty;
}
