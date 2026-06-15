using Core.Models.Entities.Menu;

namespace Core.Models.Entities.Role;

public class RoleDeletePageResponseModel
{
    public RoleResponseModel Role { get; set; }

    public List<MenuResponseModel> Menus { get; set; }

    public List<int> SelectedMenuIds { get; set; } = new List<int>();
}
