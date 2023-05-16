namespace UsersService.Application.Features.JobStatuses.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<JobStatusViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<JobStatusViewModel>>
{
  private readonly IJobStatusRepositoryAsync _JobStatusRepository;
  public GetByIdQueryHandler(IJobStatusRepositoryAsync JobStatusRepository)
  {
    _JobStatusRepository = JobStatusRepository;
  }

  public async Task<Response<JobStatusViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var JobStatus = await _JobStatusRepository.GetByIdAsync(request.Id);

    
        if(JobStatus == null)
        {
            throw new ApiException("JobStatus Not Found!");
        }
   

    return new Response<JobStatusViewModel>(JobStatus.Adapt<JobStatusViewModel>());
  }
}
