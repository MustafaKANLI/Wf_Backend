namespace UsersService.Application.Features.SharedViewModels;

public class ProjectUserViewModel
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }

}
