using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Role;

public class CreateRoleRequestModel:BaseCreateModel
{
    public string Name { get; set; } = string.Empty;
}
