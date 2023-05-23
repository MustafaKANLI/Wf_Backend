namespace UsersService.Application.Features.SharedViewModels;

public class JobTaskViewModel
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public string JobName { get; set; }
    public int AssignedUserId { get; set; }
    public string AssignedUserName { get; set; }
    public string Details { get; set; }
    public double EstimatedHour { get; set; }
    public double? EstimatedDay { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public double? ActualHour { get; set; }
    public double? ActualDay { get; set; }

}
