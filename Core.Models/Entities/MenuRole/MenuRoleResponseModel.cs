using Core.Models.Entities.Role;

namespace Core.Models.Entities.MenuRole;

public class MenuRoleResponseModel
{
    public int RoleId { get; set; }//
    public string RoleName { get; set; }
    public int MenuId { get; set; }
    public string MenuName { get; set; }
    public bool IsActive { get; set; }

}
