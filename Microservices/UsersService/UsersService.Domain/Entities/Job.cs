using Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersService.Domain.Entities
{
    public class Job : AuditableBaseEntity
    {

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [ForeignKey("JobStatus")]
        public int JobStatusId { get; set; }
        public JobStatus JobStatus { get; set; }

        [ForeignKey("JobType")]
        public int? JobTypeId { get; set; }
        public JobType JobType { get; set; }

        [ForeignKey("JobPriority")]
        public int? JobPriorityId { get; set; }
        public JobPriority JobPriority { get; set; }

        public DateTime CreateDate { get; set; }

        [ForeignKey("User")]
        public int CreateUserId { get; set; }
        public User CreateUser { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string? Topic { get; set; }
        public string Details { get; set; }
        public string? Analysis { get; set; }

        [ForeignKey("User")]
        public int? AssignedUserId { get; set; }
        public User AssignedUser { get; set; }

        [ForeignKey("Sprint")]
        public int? SprintId { get; set; }
        public Sprint Sprint { get; set; }

        public double? EstimatedDay { get; set; }
        public double? ActualDay { get; set; }
        public double? BilledDay { get; set; }
        public bool IsBilled { get; set; }

        [ForeignKey("User")]
        public int? ManagerUserId { get; set; }
        public User ManagerUser { get; set; }

        public DateTime? ManagerApproveDate { get; set; }

        [ForeignKey("User")]
        public int? DayApproverUserId { get; set; }
        public User DayApproverUser { get; set; }

        [ForeignKey("Job")]
        public int? ParentJobId { get; set; }
        public Job ParentJob { get; set; }

        public DateTime? DayApproveDate { get; set; }

        [ForeignKey("User")]
        public int? AnalysisApproverUserId { get; set; }
        public User AnalysisApproverUser { get; set; }

        public DateTime? AnalysisApproveDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? TestDate { get; set; }
        public DateTime? ProdDate { get; set; }
        public bool IsActive { get; set; }
        public int? SprintOrder { get; set; }
    }
}
