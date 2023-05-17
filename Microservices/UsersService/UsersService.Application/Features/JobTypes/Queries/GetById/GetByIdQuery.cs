namespace UsersService.Application.Features.JobTypes.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<JobTypeViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<JobTypeViewModel>>
{
  private readonly IJobTypeRepositoryAsync _JobTypeRepository;
  public GetByIdQueryHandler(IJobTypeRepositoryAsync JobTypeRepository)
  {
    _JobTypeRepository = JobTypeRepository;
  }

  public async Task<Response<JobTypeViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var JobType = await _JobTypeRepository.GetByIdAsync(request.Id);

    
        if(JobType == null)
        {
            throw new ApiException("JobType Not Found!");
        }
   

    return new Response<JobTypeViewModel>(JobType.Adapt<JobTypeViewModel>());
  }
}
