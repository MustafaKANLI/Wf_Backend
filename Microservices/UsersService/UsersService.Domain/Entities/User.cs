namespace UsersService.Domain.Entities;

using Common.Entities;

public class User : AuditableBaseEntity
{
  public int CustomerId { get; set; }
  public int ClaimId { get; set; }
  public string UserName { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string? Phone { get; set; }

    public string Password { get; set; }
    public bool IsActive { get; set; }
    public bool IsLocked { get; set; }
}
