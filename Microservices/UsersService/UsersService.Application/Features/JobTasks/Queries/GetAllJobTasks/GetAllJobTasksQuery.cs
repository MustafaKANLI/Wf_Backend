namespace UsersService.Application.Features.JobTasks.Queries.GetAllJobTasks;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobTasksQuery : IRequest<PagedResponse<IEnumerable<JobTaskViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllJobTasksQueryHandler : IRequestHandler<GetAllJobTasksQuery, PagedResponse<IEnumerable<JobTaskViewModel>>>
{
  private readonly IJobTaskRepositoryAsync _JobTasksRepository;
  public GetAllJobTasksQueryHandler(IJobTaskRepositoryAsync JobTasksRepository)
  {
    _JobTasksRepository = JobTasksRepository;
  }

  public async Task<PagedResponse<IEnumerable<JobTaskViewModel>>> Handle(GetAllJobTasksQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _JobTasksRepository.GetDataCount();
    var JobTasks = await _JobTasksRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var JobTasksViewModels = new List<JobTaskViewModel>();

    foreach (var p in JobTasks)
    {
      var JobTask = p.Adapt<JobTaskViewModel>();
      JobTasksViewModels.Add(JobTask);
    }

    return new PagedResponse<IEnumerable<JobTaskViewModel>>(JobTasksViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
