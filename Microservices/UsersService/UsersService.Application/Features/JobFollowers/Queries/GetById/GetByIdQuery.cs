namespace UsersService.Application.Features.JobFollowers.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<JobFollowerViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<JobFollowerViewModel>>
{
  private readonly IJobFollowerRepositoryAsync _JobFollowerRepository;
  public GetByIdQueryHandler(IJobFollowerRepositoryAsync JobFollowerRepository)
  {
    _JobFollowerRepository = JobFollowerRepository;
  }

  public async Task<Response<JobFollowerViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var JobFollower = await _JobFollowerRepository.GetByIdAsync(request.Id);

    
        if(JobFollower == null)
        {
            throw new ApiException("JobFollower Not Found!");
        }
   

    return new Response<JobFollowerViewModel>(JobFollower.Adapt<JobFollowerViewModel>());
  }
}
