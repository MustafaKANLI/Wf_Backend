using Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersService.Domain.Entities
{
    public class JobFile : AuditableBaseEntity
    {
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; } // Navigation property

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } // Navigation property

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ContentType { get; set; }
        public int FileSize { get; set; }
        public byte[] FileContent { get; set; }
        public bool IsActive { get; set; }
    }
}
