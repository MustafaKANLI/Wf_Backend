using Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersService.Domain.Entities
{
    public class JobQA : AuditableBaseEntity
    {
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; } // Navigation property

        [ForeignKey("User")]
        public int QuestionUserId { get; set; }
        public User QuestionUser { get; set; } // Navigation property

        public DateTime QuestionDate { get; set; }
        public string Question { get; set; }

        [ForeignKey("User")]
        public int? AnswerUserId { get; set; }
        public User AnswerUser { get; set; } // Navigation property

        public DateTime? AnswerDate { get; set; }
        public string? Answer { get; set; }
    }
}
