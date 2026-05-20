using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Menu;

public class CreateMenuRequestModel: BaseCreateModel
{
    public string ControllerName { get; set; }
    public int ParentId { get; set; }
    public string ViewName { get; set; }
    public bool IsActive { get; set; }
}
