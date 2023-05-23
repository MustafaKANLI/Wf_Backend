namespace UsersService.Application.Features.JobPriorities.Queries.GetAllJobPriorities;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobPrioritiesQuery : IRequest<PagedResponse<IEnumerable<JobPriorityViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllJobPrioritiesQueryHandler : IRequestHandler<GetAllJobPrioritiesQuery, PagedResponse<IEnumerable<JobPriorityViewModel>>>
{
  private readonly IJobPriorityRepositoryAsync _JobPriorityRepository;
  public GetAllJobPrioritiesQueryHandler(IJobPriorityRepositoryAsync JobPriorityRepository)
  {
    _JobPriorityRepository = JobPriorityRepository;
  }

  public async Task<PagedResponse<IEnumerable<JobPriorityViewModel>>> Handle(GetAllJobPrioritiesQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _JobPriorityRepository.GetDataCount();
    var JobPriorities = await _JobPriorityRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var JobPriorityViewModels = new List<JobPriorityViewModel>();

    foreach (var p in JobPriorities)
    {
      var JobPriority = p.Adapt<JobPriorityViewModel>();
      JobPriorityViewModels.Add(JobPriority);
    }

    return new PagedResponse<IEnumerable<JobPriorityViewModel>>(JobPriorityViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
