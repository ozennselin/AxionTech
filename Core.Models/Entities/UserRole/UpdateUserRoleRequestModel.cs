namespace Core.Models.Entities.UserRole;

public class UpdateUserRoleRequestModel
{
    public int OldUserId { get; set; }
    public int OldRoleId { get; set; }
    public int NewUserId { get; set; }
    public int NewRoleId { get; set; }
}
