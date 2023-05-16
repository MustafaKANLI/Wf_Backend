namespace UsersService.Application.Features.JobStatuses.Queries.GetAllJobStatuses;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobStatusesQuery : IRequest<PagedResponse<IEnumerable<JobStatusViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllJobStatusesQueryHandler : IRequestHandler<GetAllJobStatusesQuery, PagedResponse<IEnumerable<JobStatusViewModel>>>
{
  private readonly IJobStatusRepositoryAsync _JobStatusesRepository;
  public GetAllJobStatusesQueryHandler(IJobStatusRepositoryAsync JobStatusesRepository)
  {
    _JobStatusesRepository = JobStatusesRepository;
  }

  public async Task<PagedResponse<IEnumerable<JobStatusViewModel>>> Handle(GetAllJobStatusesQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _JobStatusesRepository.GetDataCount();
    var JobStatuses = await _JobStatusesRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var JobStatusesViewModels = new List<JobStatusViewModel>();

    foreach (var p in JobStatuses)
    {
      var JobStatus = p.Adapt<JobStatusViewModel>();
      JobStatusesViewModels.Add(JobStatus);
    }

    return new PagedResponse<IEnumerable<JobStatusViewModel>>(JobStatusesViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
