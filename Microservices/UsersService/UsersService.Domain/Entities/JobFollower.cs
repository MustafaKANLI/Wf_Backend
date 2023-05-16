using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersService.Domain.Entities
{
    public class JobFollower : AuditableBaseEntity
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
        
    }
}
