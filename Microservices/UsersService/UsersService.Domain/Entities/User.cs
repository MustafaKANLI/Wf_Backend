namespace UsersService.Domain.Entities;

using Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class User : AuditableBaseEntity
{
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    [ForeignKey("Claim")]
    public int ClaimId { get; set; }
    public Claim Claim { get; set; }

    public string UserName { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string? Phone { get; set; }
    public byte[]? PWSalt { get; set; }
    public byte[]? PWHash { get; set; }
    public bool IsActive { get; set; }
    public bool IsLocked { get; set; }
}
