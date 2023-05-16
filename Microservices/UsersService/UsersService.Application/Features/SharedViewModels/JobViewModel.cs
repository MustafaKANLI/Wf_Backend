namespace UsersService.Application.Features.SharedViewModels;

public class JobViewModel
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int JobStatusId { get; set; }
    public int? JobTypeId { get; set; }
    public int? JobPriorityId { get; set; }
    public DateTime CreateDate { get; set; }
    public int CreateUserId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Topic { get; set; }
    public string Details { get; set; }
    public string? Analysis { get; set; }
    public int? AssignedUserId { get; set; }
    public int? Sprint { get; set; }
    public double? EstimatedDay { get; set; }
    public double? ActualDay { get; set; }
    public double? BilledDay { get; set; }
    public bool IsBilled { get; set; }
    public int? ManagerUserId { get; set; }
    public DateTime? ManagerApproveDate { get; set; }
    public int? DayApproverUserId { get; set; }
    public int? ParentJobId { get; set; }
    public DateTime? DayApproveDate { get; set; }
    public int? AnalysisApproverUserId { get; set; }
    public DateTime? AnalysisApproveDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? TestDate { get; set; }
    public DateTime? ProdDate { get; set; }
    public bool IsActive { get; set; }
    public int? SprintOrder { get; set; }

}
