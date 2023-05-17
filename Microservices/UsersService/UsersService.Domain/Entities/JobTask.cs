using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersService.Domain.Entities
{
    public class JobTask : AuditableBaseEntity
    {
        public int JobId { get; set; }
        public int AssignedUserId { get; set; }
        public string Details { get; set; }
        public double EstimatedHour { get; set; }
        public double? EstimatedDay { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? ActualHour { get; set; }
        public double? ActualDay { get; set; }
    }
}
