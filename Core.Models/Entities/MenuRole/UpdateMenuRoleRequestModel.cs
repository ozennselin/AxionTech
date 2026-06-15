namespace Core.Models.Entities.MenuRole;

public class UpdateMenuRoleRequestModel
{
    public int RoleId { get; set; }

    public List<int> MenuIds { get; set; } = new List<int>();
}