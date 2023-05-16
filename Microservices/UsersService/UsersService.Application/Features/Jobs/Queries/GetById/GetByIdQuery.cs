namespace UsersService.Application.Features.Jobs.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<JobViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<JobViewModel>>
{
  private readonly IJobRepositoryAsync _JobRepository;
  public GetByIdQueryHandler(IJobRepositoryAsync JobRepository)
  {
    _JobRepository = JobRepository;
  }

  public async Task<Response<JobViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var Job = await _JobRepository.GetByIdAsync(request.Id);

    
        if(Job == null)
        {
            throw new ApiException("Job Not Found!");
        }
   

    return new Response<JobViewModel>(Job.Adapt<JobViewModel>());
  }
}
