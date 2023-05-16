namespace UsersService.Application.Features.Jobs.Queries.GetAllJobs;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobsQuery : IRequest<PagedResponse<IEnumerable<JobViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, PagedResponse<IEnumerable<JobViewModel>>>
{
  private readonly IJobRepositoryAsync _JobRepository;
  public GetAllJobsQueryHandler(IJobRepositoryAsync JobRepository)
  {
    _JobRepository = JobRepository;
  }

  public async Task<PagedResponse<IEnumerable<JobViewModel>>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _JobRepository.GetDataCount();
    var Jobs = await _JobRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var JobViewModels = new List<JobViewModel>();

    foreach (var p in Jobs)
    {
      var Job = p.Adapt<JobViewModel>();
      JobViewModels.Add(Job);
    }

    return new PagedResponse<IEnumerable<JobViewModel>>(JobViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
