namespace UsersService.Application.Features.SharedViewModels;

public class JobCommentViewModel
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public string JobName { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public string Comment { get; set; }

}
