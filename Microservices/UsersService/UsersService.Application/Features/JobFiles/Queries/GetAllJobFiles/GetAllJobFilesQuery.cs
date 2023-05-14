namespace UsersService.Application.Features.JobFiles.Queries.GetAllJobFiles;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobFilesQuery : IRequest<PagedResponse<IEnumerable<JobFileViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllJobFilesQueryHandler : IRequestHandler<GetAllJobFilesQuery, PagedResponse<IEnumerable<JobFileViewModel>>>
{
  private readonly IJobFileRepositoryAsync _JobFileRepository;
  public GetAllJobFilesQueryHandler(IJobFileRepositoryAsync JobFileRepository)
  {
    _JobFileRepository = JobFileRepository;
  }

  public async Task<PagedResponse<IEnumerable<JobFileViewModel>>> Handle(GetAllJobFilesQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _JobFileRepository.GetDataCount();
    var JobFiles = await _JobFileRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var JobFileViewModels = new List<JobFileViewModel>();

    foreach (var p in JobFiles)
    {
      var JobFile = p.Adapt<JobFileViewModel>();
      JobFileViewModels.Add(JobFile);
    }

    return new PagedResponse<IEnumerable<JobFileViewModel>>(JobFileViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
