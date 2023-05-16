namespace UsersService.Application.Features.JobQAs.Queries.GetAllJobQAs;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobQAsQuery : IRequest<PagedResponse<IEnumerable<JobQAViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllJobQAsQueryHandler : IRequestHandler<GetAllJobQAsQuery, PagedResponse<IEnumerable<JobQAViewModel>>>
{
  private readonly IJobQARepositoryAsync _JobQARepository;
  public GetAllJobQAsQueryHandler(IJobQARepositoryAsync JobQARepository)
  {
    _JobQARepository = JobQARepository;
  }

  public async Task<PagedResponse<IEnumerable<JobQAViewModel>>> Handle(GetAllJobQAsQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _JobQARepository.GetDataCount();
    var JobQAs = await _JobQARepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var JobQAViewModels = new List<JobQAViewModel>();

    foreach (var p in JobQAs)
    {
      var JobQA = p.Adapt<JobQAViewModel>();
      JobQAViewModels.Add(JobQA);
    }

    return new PagedResponse<IEnumerable<JobQAViewModel>>(JobQAViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
