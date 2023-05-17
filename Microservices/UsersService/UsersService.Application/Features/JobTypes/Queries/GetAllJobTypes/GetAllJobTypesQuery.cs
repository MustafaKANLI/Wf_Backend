namespace UsersService.Application.Features.JobTypes.Queries.GetAllJobTypes;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobTypesQuery : IRequest<PagedResponse<IEnumerable<JobTypeViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllJobTypesQueryHandler : IRequestHandler<GetAllJobTypesQuery, PagedResponse<IEnumerable<JobTypeViewModel>>>
{
  private readonly IJobTypeRepositoryAsync _JobTypesRepository;
  public GetAllJobTypesQueryHandler(IJobTypeRepositoryAsync JobTypesRepository)
  {
    _JobTypesRepository = JobTypesRepository;
  }

  public async Task<PagedResponse<IEnumerable<JobTypeViewModel>>> Handle(GetAllJobTypesQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _JobTypesRepository.GetDataCount();
    var JobTypes = await _JobTypesRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var JobTypesViewModels = new List<JobTypeViewModel>();

    foreach (var p in JobTypes)
    {
      var JobType = p.Adapt<JobTypeViewModel>();
      JobTypesViewModels.Add(JobType);
    }

    return new PagedResponse<IEnumerable<JobTypeViewModel>>(JobTypesViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
