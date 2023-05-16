namespace UsersService.Application.Features.SharedViewModels;

public class JobStatusViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? PreviousStatus { get; set; }
    public int? NextStatus { get; set; }
    public string? Description { get; set; }

}
