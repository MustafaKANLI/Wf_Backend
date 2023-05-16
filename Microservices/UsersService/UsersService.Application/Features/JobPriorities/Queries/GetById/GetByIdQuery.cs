namespace UsersService.Application.Features.JobPriorities.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<JobPriorityViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<JobPriorityViewModel>>
{
  private readonly IJobPriorityRepositoryAsync _JobPriorityRepository;
  public GetByIdQueryHandler(IJobPriorityRepositoryAsync JobPriorityRepository)
  {
    _JobPriorityRepository = JobPriorityRepository;
  }

  public async Task<Response<JobPriorityViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var JobPriority = await _JobPriorityRepository.GetByIdAsync(request.Id);

    
        if(JobPriority == null)
        {
            throw new ApiException("JobPriority Not Found!");
        }
   

    return new Response<JobPriorityViewModel>(JobPriority.Adapt<JobPriorityViewModel>());
  }
}
