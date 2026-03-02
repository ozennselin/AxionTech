namespace Data.Infrastructure.Abstraction;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public int CreatorId { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int? UpdaterId { get; set; }
}
