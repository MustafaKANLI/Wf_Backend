namespace UsersService.Application.Features.JobComments.Queries.GetAllJobComments;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobCommentsQuery : IRequest<PagedResponse<IEnumerable<JobCommentViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllJobCommentsQueryHandler : IRequestHandler<GetAllJobCommentsQuery, PagedResponse<IEnumerable<JobCommentViewModel>>>
{
  private readonly IJobCommentRepositoryAsync _JobCommentsRepository;
  public GetAllJobCommentsQueryHandler(IJobCommentRepositoryAsync JobCommentsRepository)
  {
    _JobCommentsRepository = JobCommentsRepository;
  }

  public async Task<PagedResponse<IEnumerable<JobCommentViewModel>>> Handle(GetAllJobCommentsQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _JobCommentsRepository.GetDataCount();
    var JobComments = await _JobCommentsRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var JobCommentsViewModels = new List<JobCommentViewModel>();

    foreach (var p in JobComments)
    {
      var JobComment = p.Adapt<JobCommentViewModel>();
      JobCommentsViewModels.Add(JobComment);
    }

    return new PagedResponse<IEnumerable<JobCommentViewModel>>(JobCommentsViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
