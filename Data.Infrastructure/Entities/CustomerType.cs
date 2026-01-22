using Data.Infrastructure.Abstraction;

namespace Data.Infrastructure.Entities;

public class CustomerType:BaseEntity
{
    public string Name { get; set; } = string.Empty; 

    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
