using Data.Infrastructure.Abstraction;

namespace Data.Infrastructure.Entities;

public class User:BaseEntity
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

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
  
}

