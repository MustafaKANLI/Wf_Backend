using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
