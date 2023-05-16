using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersService.Domain.Entities
{
    public class JobQA : AuditableBaseEntity
    {
        public int JobId { get; set; }
        public int QuestionUserId { get; set; }
        public DateTime QuestionDate { get; set; }
        public string Question { get; set; }
        public int? AnswerUserId { get; set; }
        public DateTime? AnswerDate { get; set; }
        public string? Answer { get; set; }

    }
}
