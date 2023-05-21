using Common.Entities;

namespace UsersService.Domain.Entities;

public class Customer : AuditableBaseEntity
{
    public string Name { get; set; }
}
