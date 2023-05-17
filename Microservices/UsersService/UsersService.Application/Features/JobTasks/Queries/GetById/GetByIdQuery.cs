namespace UsersService.Application.Features.JobTasks.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<JobTaskViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<JobTaskViewModel>>
{
  private readonly IJobTaskRepositoryAsync _JobTaskRepository;
  public GetByIdQueryHandler(IJobTaskRepositoryAsync JobTaskRepository)
  {
    _JobTaskRepository = JobTaskRepository;
  }

  public async Task<Response<JobTaskViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var JobTask = await _JobTaskRepository.GetByIdAsync(request.Id);

    
        if(JobTask == null)
        {
            throw new ApiException("JobTask Not Found!");
        }
   

    return new Response<JobTaskViewModel>(JobTask.Adapt<JobTaskViewModel>());
  }
}
