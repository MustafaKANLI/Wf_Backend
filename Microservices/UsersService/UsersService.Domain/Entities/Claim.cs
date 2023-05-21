using Common.Entities;

namespace UsersService.Domain.Entities
{
    public class Claim : AuditableBaseEntity
    {
        public string Name { get; set; }
    }
}
