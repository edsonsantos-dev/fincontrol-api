using FinControl.Business.Models.Enums;

namespace FinControl.Business.Models;

public class User : AuditableEntity
{
    public override Guid Id => Role == UserRole.Owner ? AccountId : Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public UserRole Role { get; set; }
} 