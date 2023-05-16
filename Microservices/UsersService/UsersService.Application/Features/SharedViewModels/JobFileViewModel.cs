namespace UsersService.Application.Features.SharedViewModels;

public class JobFileViewModel
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string ContentType { get; set; }
    public int FileSize { get; set; }
    public byte[] FileContent { get; set; }
    public bool IsActive { get; set; }

}
