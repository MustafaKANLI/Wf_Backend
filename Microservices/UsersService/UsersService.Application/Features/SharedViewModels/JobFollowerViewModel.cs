namespace UsersService.Application.Features.SharedViewModels;

public class JobFollowerViewModel
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public string JobName { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }

}
