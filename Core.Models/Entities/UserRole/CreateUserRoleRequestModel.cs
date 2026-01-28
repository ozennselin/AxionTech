using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.UserRole;

public class CreateUserRoleRequestModel:BaseCreateModel
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}
