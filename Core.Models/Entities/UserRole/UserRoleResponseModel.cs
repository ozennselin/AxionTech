namespace Core.Models.Entities.UserRole;

public class UserRoleResponseModel
{
    public int UserId { get; set; }
    public int RoleId { get; set; }

    public string RoleName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}
