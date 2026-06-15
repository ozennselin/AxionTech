using Core.Models.Entities.Menu;
using Core.Models.Entities.Role;

namespace Core.Models.Entities.MenuRole;

public class MenuRoleCreatePageResponseModel
{
    public List<RoleResponseModel> Roles { get; set; }

    public List<MenuResponseModel> Menus { get; set; }
    public List<int> SelectedMenuIds { get; set; } = new List<int>();
}