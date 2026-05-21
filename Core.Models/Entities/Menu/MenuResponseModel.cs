namespace Core.Models.Entities.Menu;

public class MenuResponseModel
{
    public int Id { get; set; }
    public string ControllerName { get; set; }
    public int ParentId { get; set; }
    public string ViewName { get; set; }
    public bool IsActive { get; set; }
}