namespace UsersService.Application.Features.JobFollowers.Queries.GetAllJobFollowers;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobFollowersQuery : IRequest<PagedResponse<IEnumerable<JobFollowerViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllJobFollowersQueryHandler : IRequestHandler<GetAllJobFollowersQuery, PagedResponse<IEnumerable<JobFollowerViewModel>>>
{
  private readonly IJobFollowerRepositoryAsync _JobFollowerRepository;
  public GetAllJobFollowersQueryHandler(IJobFollowerRepositoryAsync JobFollowerRepository)
  {
    _JobFollowerRepository = JobFollowerRepository;
  }

  public async Task<PagedResponse<IEnumerable<JobFollowerViewModel>>> Handle(GetAllJobFollowersQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _JobFollowerRepository.GetDataCount();
    var JobFollowers = await _JobFollowerRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var JobFollowerViewModels = new List<JobFollowerViewModel>();

    foreach (var p in JobFollowers)
    {
      var JobFollower = p.Adapt<JobFollowerViewModel>();
      JobFollowerViewModels.Add(JobFollower);
    }

    return new PagedResponse<IEnumerable<JobFollowerViewModel>>(JobFollowerViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
