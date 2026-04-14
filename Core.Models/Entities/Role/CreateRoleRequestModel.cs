using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Role;

public class CreateRoleRequestModel:BaseCreateModel
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}
