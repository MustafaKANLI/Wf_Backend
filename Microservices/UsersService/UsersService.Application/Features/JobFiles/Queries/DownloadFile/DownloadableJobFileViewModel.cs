namespace UsersService.Application.Features.SharedViewModels;

public class DownloadableJobFileViewModel
{
    public MemoryStream FileContent { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }

}
