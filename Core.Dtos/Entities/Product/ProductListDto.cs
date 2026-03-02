namespace Core.Dtos.Entities.Product
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string Picture { get; set; } = string.Empty;
        public decimal Price { get; set; }

    }
}
