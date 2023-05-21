using Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersService.Domain.Entities
{
    public class ProjectUser : AuditableBaseEntity
    {
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
