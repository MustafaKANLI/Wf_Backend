using Common.Entities;

namespace UsersService.Domain.Entities
{
    public class JobType : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string? Details { get; set; }
    }
}
