using Core.Models.Entities.Abstraction;

namespace Core.Models.Entities.User;

public class CreateUserRequestModel:BaseCreateModel
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }
    public string PasswordHash { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }

    public bool IsActive { get; set; } = true;
    public bool IsEmailConfirmed { get; set; } = false;
}
