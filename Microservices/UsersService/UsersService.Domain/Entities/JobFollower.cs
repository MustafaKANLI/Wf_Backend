﻿using Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersService.Domain.Entities
{
    public class JobFollower : AuditableBaseEntity
    {
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; } // Navigation property

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } // Navigation property
    }
}
