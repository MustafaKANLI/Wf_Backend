using Common.Entities;

namespace UsersService.Domain.Entities;

public class JobPriority : AuditableBaseEntity
{
    public string Name { get; set; }
}
