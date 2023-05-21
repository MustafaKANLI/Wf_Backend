using Common.Entities;

namespace UsersService.Domain.Entities
{
    public class JobStatus : AuditableBaseEntity
    {
        public string Name { get; set; }
        public int? PreviousStatus { get; set; }
        public int? NextStatus { get; set; }
        public string? Description { get; set; }
    }
}
