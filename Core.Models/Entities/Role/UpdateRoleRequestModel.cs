using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.Role;

public class UpdateRoleRequestModel:BaseUpdateModel
{
    public string Name { get; set; } = string.Empty;
}
