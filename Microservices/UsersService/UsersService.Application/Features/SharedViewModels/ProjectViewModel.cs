namespace UsersService.Application.Features.SharedViewModels;

public class ProjectViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Code { get; set; }
    public int ManagerUserId { get; set; }
    public string ManagerUserName { get; set; }
    public int AnalysisApproverUserId { get; set; }
    public string AnalysisApproverUserName { get; set; }
    public int DayApproverUserId { get; set; }
    public bool? IsActive { get; set; }

}
