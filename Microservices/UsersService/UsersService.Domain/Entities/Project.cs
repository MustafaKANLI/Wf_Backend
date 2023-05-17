using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersService.Domain.Entities
{
    public class Project : AuditableBaseEntity
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public string Code { get; set; }
        public int ManagerUserId { get; set; }
        public int AnalysisApproverUserId { get; set; }
        public int DayApproverUserId { get; set; }
        public bool? IsActive { get; set; }
    }
}
