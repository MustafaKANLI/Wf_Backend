using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersService.Domain.Entities
{
    public class JobFile : AuditableBaseEntity
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ContentType { get; set; }
        public int FileSize { get; set; }
        public byte[] FileContent { get; set; }
        public bool IsActive { get; set; }
    }
}
