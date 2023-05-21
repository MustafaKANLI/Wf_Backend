using Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersService.Domain.Entities
{
    public class Project : AuditableBaseEntity
    {
        public string Name { get; set; }
        
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string Code { get; set; }

        [ForeignKey("User")]
        public int ManagerUserId { get; set; }
        public User ManagerUser { get; set; }

        [ForeignKey("User")]
        public int AnalysisApproverUserId { get; set; }
        public User AnalysisApproverUser { get; set; }

        [ForeignKey("User")]
        public int DayApproverUserId { get; set; }
        public User DayApproverUser { get; set; }

        public bool? IsActive { get; set; }
    }
}
