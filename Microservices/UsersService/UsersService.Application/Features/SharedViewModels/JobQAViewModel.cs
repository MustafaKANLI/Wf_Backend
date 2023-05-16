namespace UsersService.Application.Features.SharedViewModels;

public class JobQAViewModel
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public int QuestionUserId { get; set; }
    public DateTime QuestionDate { get; set; }
    public string Question { get; set; }
    public int? AnswerUserId { get; set; }
    public DateTime? AnswerDate { get; set; }
    public string? Answer { get; set; }

}
