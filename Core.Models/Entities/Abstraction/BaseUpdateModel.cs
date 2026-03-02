namespace Core.Models.Entities.Abstraction;

public abstract class BaseUpdateModel
{
    public int Id { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int? UpdaterId { get; set; }
}
