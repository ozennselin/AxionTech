namespace AxionTech.API.Controllers
{
    public class ProductInsertRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int  Stock { get; set; }
        public double Price { get; set; }
    }
}
