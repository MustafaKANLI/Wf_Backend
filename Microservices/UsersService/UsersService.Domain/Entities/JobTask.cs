﻿using Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace UsersService.Domain.Entities
{
    public class JobTask : AuditableBaseEntity
    {
        [ForeignKey("JobId")]
        public int JobId { get; set; }
        public Job Job { get; set; }

        [ForeignKey("AssignedUserId")]
        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }

        public string Details { get; set; }
        public double EstimatedHour { get; set; }
        public double? EstimatedDay { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? ActualHour { get; set; }
        public double? ActualDay { get; set; }
    }
}
