namespace Core.Models.Entities.Abstraction;

public abstract class BaseCreateModel
{
    public DateTime CreateDate { get; set; }
    public int CreatorId { get; set; }
}
